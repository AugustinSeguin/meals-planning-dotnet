#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MealsPlanning.Data;
using MealsPlanning.Models;

namespace MealsPlanning.Areas.Ingredients.Pages
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
        public Ingredient Ingredient { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            var ingredient = new Ingredient();

            if (await TryUpdateModelAsync(ingredient, "ingredient", i => i.Name))
            {
                Console.Write("Ingredient: " + ingredient.Name);
                ctx.Ingredients.Add(ingredient);
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}