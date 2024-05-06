#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MealsPlanning.Data;
using MealsPlanning.Models;

namespace MealsPlanning.Areas.Recipes.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext ctx;

        public CreateModel(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = new Recipe
        {
            Name = "Name"
        };

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
    }
}