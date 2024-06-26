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
        public Ingredient Ingredient { get; set; } = new Ingredient
        {
            Name = "Name"
        };

        public async Task<IActionResult> OnPostAsync()
        {
            var ingredient = new Ingredient
            {
                Name = "Name"
            };

            if (await TryUpdateModelAsync(ingredient, "ingredient", i => i.Name))
            {
                ctx.Ingredients.Add(ingredient);
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}