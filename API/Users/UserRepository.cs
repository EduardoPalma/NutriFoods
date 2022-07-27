using API.Dto;
using API.Utils;
using API.Utils.Nutrition;
using AutoMapper;
using Domain.Enum;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace API.Users;

public class UserRepository : IUserRepository
{
    private readonly NutrifoodsDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(NutrifoodsDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto?> Find(string apiKey)
    {
        var user = await _mapper.ProjectTo<UserDto>(IncludeSubfields(_context.UserProfiles))
            .FirstOrDefaultAsync(e => e.ApiKey.Equals(apiKey));
        return user;
    }

    public async Task<UserDto?> FindByUsername(string username, string password)
    {
        var user = await _mapper.ProjectTo<UserDto>(IncludeSubfields(_context.UserProfiles))
            .FirstOrDefaultAsync(e => e.Username.ToLower().Equals(username));
        if (user == null) return null;
        return PasswordEncryption.Verify(password, user.Password) ? user : null;
    }

    public async Task<UserDto?> FindByEmail(string email, string password)
    {
        var user = await _mapper.ProjectTo<UserDto>(IncludeSubfields(_context.UserProfiles))
            .FirstOrDefaultAsync(e => e.Email.ToLower().Equals(email));
        if (user == null) return null;
        return PasswordEncryption.Verify(password, user.Password) ? user : null;
    }

    public async Task<UserDto?> SaveUser(string username, string email, string password, string? name, string? lastName,
        DateOnly birthDate, Gender gender)
    {
        var user = await _mapper.ProjectTo<UserDto>(_context.UserProfiles)
            .FirstOrDefaultAsync(e => e.Username.ToLower().Equals(username) || e.Email.ToLower().Equals(email));
        if (user != null) return null;
        var newUser = new UserProfile
        {
            Username = username,
            Email = email,
            ApiKey = ApiKeyGenerator.Generate(),
            Password = PasswordEncryption.Hash(password),
            Name = name ?? string.Empty,
            LastName = lastName ?? string.Empty,
            Birthdate = birthDate,
            Gender = gender,
            JoinedOn = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Local)
        };
        _context.UserProfiles.Add(newUser);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserProfile, UserDto>(newUser);
    }

    public async Task<UserDto?> SaveBodyMetrics(string apiKey, int height, double weight, PhysicalActivity level,
        double? muscleMassPercentage)
    {
        var user = await Find(apiKey);
        if (user == null) return null;
        var bodyMetric = new UserBodyMetric
        {
            UserId = user.Id,
            Height = height,
            Weight = weight,
            BodyMassIndex = BodyMassIndex.Calculate(weight, height),
            PhysicalActivityLevel = level,
            MuscleMassPercentage = muscleMassPercentage
        };
        _context.UserBodyMetrics.Add(bodyMetric);
        await _context.SaveChangesAsync();
        var bodyMetricDto = _mapper.Map<UserBodyMetric, UserBodyMetricDto>(bodyMetric);
        user.BodyMetrics.Add(bodyMetricDto);
        return user;
    }

    private static IQueryable<UserProfile> IncludeSubfields(IQueryable<UserProfile> users)
    {
        return users.Include(e => e.Diet)
            .Include(e => e.MealPlan)
            .ThenInclude(e => e!.MealMenus)
            .ThenInclude(e => e.MealMenuRecipes)
            .ThenInclude(e => e.Recipe.RecipeNutrients)
            .ThenInclude(e => e.Nutrient.Subtype.Type)
            .Include(e => e.MealPlan)
            .ThenInclude(e => e!.MealMenus)
            .ThenInclude(e => e.MealMenuRecipes)
            .ThenInclude(e => e.Recipe.RecipeMeasures)
            .ThenInclude(e => e.IngredientMeasure.Ingredient)
            .Include(e => e.UserBodyMetrics);
    }
}