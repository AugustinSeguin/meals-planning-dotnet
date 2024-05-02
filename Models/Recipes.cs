
using MealsPlanning.Models.Ingredients;

namespace MealsPlanning.Models.Recipes;

enum Level
{
    Low,
    Medium,
    High
}


public class Recipes
{
    public required int Id { get; set; }

    public required String Name { get; set; }

    public required int Level { get; set; }

    public required int NbMeals { get; set; }

    // public virtual List<Ingredients>? {get; set;}

}