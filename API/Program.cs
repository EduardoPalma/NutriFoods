using System.Text.Json.Serialization;
using API.Ingredients;
using API.Recipes;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.EntityFrameworkCore;

/*
DatabaseInitialization.Initialize();
ApiRetrieval.RetrieveFromApi();
Connect.InsertMeasuris();
Connect.InsertRecipe();
Connect.InsertRecipeIngredient();
NutrientCalculation.Calculate();
*/


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NutrifoodsDbContext>(optionsBuilder =>
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"),
                opt => opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
    }
);

builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
        {
            ["activated"] = false
        };
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();