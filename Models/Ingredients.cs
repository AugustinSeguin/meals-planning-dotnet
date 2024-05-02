
namespace MealsPlanning.Models.Ingredients;

public class Ingredients
{
    public required int Id { get; set; }

    public required String Name { get; set; }

    public required int Level { get; set; }

    public required int NbMeals { get; set; }
}