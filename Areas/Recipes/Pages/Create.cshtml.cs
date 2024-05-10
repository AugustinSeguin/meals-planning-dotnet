#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MealsPlanning.Data;
using MealsPlanning.Models;
using Microsoft.EntityFrameworkCore;

namespace MealsPlanning.Areas.Recipes.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext ctx;


        public CreateModel(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = new Recipe
        {
            Name = "Name"
        };
        public IList<Ingredient> Ingredients { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Ingredients = await ctx.Ingredients.AsNoTracking().ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var recipe = new Recipe
            {
                Name = "Name"
            };

            if (await TryUpdateModelAsync(recipe, "recipe", r => r.Name, r => r.Level, r => r.NbMeals, r => r.Instructions))
            {
                ctx.Recipes.Add(recipe);
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> DeleteRecipeIngredient(int id)
        {
            RecipeIngredient recipeIngredients = await ctx.RecipeIngredients.FindAsync(id);

            if (recipeIngredients != null)
            {
                ctx.RecipeIngredients.Remove(recipeIngredients);
                await ctx.SaveChangesAsync();
            }
            return Page();
        }

        public async Task<IActionResult> AddRecipeIngredient(int id)
        {
            RecipeIngredient recipeIngredients = new RecipeIngredient
            {
                Recipe = Recipe,
                Ingredient = Ingredients.FirstOrDefault(i => i.Id == id)
            };
            ctx.RecipeIngredients.Add(recipeIngredients);
            await ctx.SaveChangesAsync();
            return Page();
        }
    }
}