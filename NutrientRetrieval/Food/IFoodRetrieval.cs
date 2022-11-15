using Domain.Models;
using Microsoft.EntityFrameworkCore;
using NutrientRetrieval.Dictionaries;
using NutrientRetrieval.Request;

namespace NutrientRetrieval.Food;

public interface IFoodRetrieval<in T> where T : class, IFood
{
    public void RetrieveFromApi(string connectionString, string format)
    {
        var options = new DbContextOptionsBuilder<NutrifoodsDbContext>()
            .UseNpgsql(connectionString)
            .Options;
        using var context = new NutrifoodsDbContext(options);
        var nutrientsDictionary = NutrientDictionary.CreateDictionaryIds();
        var foodsDictionary = DataCentral.RetrieveByList<T>(format).Result.ToDictionary(e => e.Key, e => e.Value);
        Console.WriteLine(foodsDictionary.Count);
        foreach (var pair in foodsDictionary)
        {
            InsertNutrients(context, nutrientsDictionary, pair.Key, pair.Value);
            InsertMeasures(context, pair.Key, pair.Value);
        }

        context.SaveChanges();
    }

    void InsertNutrients(NutrifoodsDbContext context, IReadOnlyDictionary<string, int> dictionary, int ingredientId,
        T food);

    void InsertMeasures(NutrifoodsDbContext context, int ingredientId, T food);
}