#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealsPlanning.Data;
using MealsPlanning.Models;

namespace MealsPlanning.Areas.Ingredients.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext ctx;

        public DeleteModel(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? hasErrorMessage = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient = await ctx.Ingredients
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Ingredient == null)
            {
                return NotFound();
            }

            if (hasErrorMessage.GetValueOrDefault())
            {
                ErrorMessage = $"Une erreur est survenue lors de la tentative de suppression de {Ingredient.Name} ({Ingredient.Id})";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientToDelete = await ctx.Ingredients
                .FirstOrDefaultAsync(f => f.Id == id);

            if (ingredientToDelete == null)
            {
                return NotFound();
            }

            try
            {
                ctx.Ingredients.Remove(ingredientToDelete);
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