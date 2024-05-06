#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealsPlanning.Data;
using MealsPlanning.Models;

namespace MealsPlanning.Areas.Recipes.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext ctx;

        public DeleteModel(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? hasErrorMessage = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await ctx.Recipes
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Recipe == null)
            {
                return NotFound();
            }

            if (hasErrorMessage.GetValueOrDefault())
            {
                ErrorMessage = $"Une erreur est survenue lors de la tentative de suppression de {Recipe.Name} ({Recipe.Id})";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeToDelete = await ctx.Recipes
                .FirstOrDefaultAsync(f => f.Id == id);

            if (recipeToDelete == null)
            {
                return NotFound();
            }

            try
            {
                ctx.Recipes.Remove(recipeToDelete);
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                return RedirectToAction("./Delete", new { id, hasErrorMessage = true });
            }
        }
    }
}