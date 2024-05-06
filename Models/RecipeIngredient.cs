
namespace MealsPlanning.Models;

public class RecipeIngredient
{
    public int Id { get; set; }

    public required Recipe Recipe { get; set; }
    public required Ingredient Ingredient { get; set; }
}