using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealsPlanning.Models;



public class Recipe
{
    public enum Levels
    {
        Facile,
        Moyen,
        Difficile
    }

    public int Id { get; set; }

    [Display(Name = "Nom")]
    public required String Name { get; set; }

    [Display(Name = "Difficulté")]
    public int Level { get; set; }
    [Display(Name = "Nombre de repas")]
    public int NbMeals { get; set; }

    public String? Instructions { get; set; }

    public List<RecipeIngredient>? RecipeIngredient { get; set; }
}