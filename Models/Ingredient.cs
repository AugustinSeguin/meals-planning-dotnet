using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MealsPlanning.Models;

public class Ingredient
{
    public int Id { get; set; }

    [Display(Name = "Nom")]
    public required String Name { get; set; }

    public List<RecipeIngredient>? RecipeIngredient { get; set; }
}