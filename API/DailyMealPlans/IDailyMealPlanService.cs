using API.Dto;
using Utils.Enum;

namespace API.DailyMealPlans;

public interface IDailyMealPlanService
{
    public DailyMealPlanDto GenerateDailyMealPlan(double energyTarget,
        ICollection<(MealTypeEnum MealType, SatietyEnum Satiety)> mealConfigurations, DayOfTheWeek dayOfTheWeek);
}