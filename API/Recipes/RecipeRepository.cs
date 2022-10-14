using API.Dto;
using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Recipes;

public class RecipeRepository : IRecipeRepository
{
    private readonly List<int> _nonLactoVegetarianIds = new() {10, 11, 12, 13, 14};
    private readonly List<int> _nonOvoLactoVegetarianIds = new() {10, 11, 12, 13};
    private readonly List<int> _nonOvoVegetarianIds = new() {10, 11, 12, 13, 18, 19, 20};
    private readonly List<int> _nonPescetarianIds = new() {12, 13, 14};
    private readonly List<int> _nonPolloPescetarianIds = new() {12, 14};
    private readonly List<int> _nonPollotarianIds = new() {10, 11, 12, 14};
    private readonly List<int> _nonVegetarianIds = new() {10, 11};
    
    private readonly NutrifoodsDbContext _context;
    private readonly IMapper _mapper;

    public RecipeRepository(NutrifoodsDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RecipeDto>> FindAll()
    {
        return await _mapper.ProjectTo<RecipeDto>(IncludeSubfields(_context.Recipes)).ToListAsync();
    }

    public async Task<RecipeDto> FindByName(string name)
    {
        return await _mapper.ProjectTo<RecipeDto>(IncludeSubfields(_context.Recipes))
            .Where(e => e.Name.Equals(name))
            .FirstAsync();
    }

    public async Task<RecipeDto> FindById(int id)
    {
        return await _mapper.ProjectTo<RecipeDto>(_context.Recipes).Where(e => e.Id == id).FirstAsync();
    }
    
    public async Task<List<RecipeDto>> GetVegetarianRecipes()
    {
        return await ExcludeSecondaryGroups(_nonVegetarianIds);
    }

    public async Task<List<RecipeDto>> GetOvoVegetarianRecipes()
    {
        return await ExcludeTertiaryGroups(_nonOvoVegetarianIds);
    }

    public async Task<List<RecipeDto>> GetOvoLactoVegetarianRecipes()
    {
        return await ExcludeTertiaryGroups(_nonOvoLactoVegetarianIds);
    }

    public async Task<List<RecipeDto>> GetLactoVegetarianRecipes()
    {
        return await ExcludeTertiaryGroups(_nonLactoVegetarianIds);
    }

    public async Task<List<RecipeDto>> GetPollotarianRecipes()
    {
        return await ExcludeTertiaryGroups(_nonPollotarianIds);
    }

    public async Task<List<RecipeDto>> GetPescetarianRecipes()
    {
        return await ExcludeTertiaryGroups(_nonPescetarianIds);
    }

    public async Task<List<RecipeDto>> GetPolloPescetarianRecipes()
    {
        return await ExcludeTertiaryGroups(_nonPolloPescetarianIds);
    }
    
    public async Task<List<RecipeDto>> FilterByPreparationTime(int lowerBound, int upperBound)
    {
        return await _mapper.ProjectTo<RecipeDto>(IncludeSubfields(_context.Recipes)
                .Where(e => e.PreparationTime != null && e.PreparationTime >= lowerBound &&
                            e.PreparationTime <= upperBound))
            .ToListAsync();
    }

    public async Task<List<RecipeDto>> FilterByPortions(int portions)
    {
        return await _mapper.ProjectTo<RecipeDto>(IncludeSubfields(_context.Recipes)
                .Where(e => e.Portions != null && e.Portions == portions))
            .ToListAsync();
    }

    public async Task<List<RecipeDto>> FilterByPortions(int lowerBound, int upperBound)
    {
        return await _mapper.ProjectTo<RecipeDto>(IncludeSubfields(_context.Recipes)
                .Where(e => e.Portions != null && e.Portions >= lowerBound && e.Portions <= upperBound))
            .ToListAsync();
    }

    public async Task<List<RecipeDto>> FilterByEnergy(int lowerBound, int upperBound)
    {
        return await FilterByNutrientQuantity(1, lowerBound, upperBound);
    }

    public async Task<List<RecipeDto>> FilterByCarbohydrates(int lowerBound, int upperBound)
    {
        return await FilterByNutrientQuantity(2, lowerBound, upperBound);
    }

    public async Task<List<RecipeDto>> FilterByLipids(int lowerBound, int upperBound)
    {
        return await FilterByNutrientQuantity(12, lowerBound, upperBound);
    }

    public async Task<List<RecipeDto>> FilterByProteins(int lowerBound, int upperBound)
    {
        return await FilterByNutrientQuantity(63, lowerBound, upperBound);
    }

    private async Task<List<RecipeDto>> FilterByNutrientQuantity(int id, int lowerBound, int upperBound)
    {
        return await _mapper.ProjectTo<RecipeDto>(IncludeSubfields(_context.Recipes)
                .Where(e => e.RecipeNutrients.Any(
                    x => x.NutrientId == id && x.Quantity >= lowerBound && x.Quantity <= upperBound)))
            .ToListAsync();
    }

    private async Task<List<RecipeDto>> ExcludeSecondaryGroups(IEnumerable<int> ids)
    {
        return await _mapper.ProjectTo<RecipeDto>(IncludeSubfields(_context.Recipes)
                .Where(e => !e.RecipeMeasures.Any(m =>
                    ids.Contains(m.IngredientMeasure.Ingredient.TertiaryGroup.SecondaryGroup.Id)))
                .Where(e => !e.RecipeQuantities.Any(m =>
                    ids.Contains(m.Ingredient.TertiaryGroup.SecondaryGroup.Id))))
            .ToListAsync();
    }

    private async Task<List<RecipeDto>> ExcludeTertiaryGroups(IEnumerable<int> ids)
    {
        return await _mapper.ProjectTo<RecipeDto>(IncludeSubfields(_context.Recipes)
                .Where(e => !e.RecipeMeasures.Any(m =>
                    ids.Contains(m.IngredientMeasure.Ingredient.TertiaryGroup.Id)))
                .Where(e => !e.RecipeQuantities.Any(m =>
                    ids.Contains(m.Ingredient.TertiaryGroup.Id))))
            .ToListAsync();
    }

    private static IQueryable<Recipe> IncludeSubfields(IQueryable<Recipe> recipes)
    {
        return recipes
            .Include(e => e.RecipeSteps)
            .Include(e => e.RecipeNutrients)
            .ThenInclude(e => e.Nutrient)
            .ThenInclude(e => e.Subtype)
            .ThenInclude(e => e.Type)
            .Include(e => e.RecipeMeasures)
            .ThenInclude(e => e.IngredientMeasure)
            .ThenInclude(e => e.Ingredient)
            .ThenInclude(e => e.TertiaryGroup)
            .ThenInclude(e => e.SecondaryGroup)
            .ThenInclude(e => e.PrimaryGroup)
            .Include(e => e.RecipeQuantities)
            .ThenInclude(e => e.Ingredient)
            .ThenInclude(e => e.TertiaryGroup)
            .ThenInclude(e => e.SecondaryGroup)
            .ThenInclude(e => e.PrimaryGroup)
            .AsNoTracking();
    }
}