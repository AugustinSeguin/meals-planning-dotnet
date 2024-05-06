#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealsPlanning.Data;
using MealsPlanning.Models;

namespace MealsPlanning.Areas.Ingredients.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext ctx;

        public EditModel(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient = await ctx.Ingredients
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Ingredient == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var ingredientToUpdate = await ctx.Ingredients
                .FirstOrDefaultAsync(f => f.Id == id);

            if (ingredientToUpdate == null)
                return NotFound();

            if (await TryUpdateModelAsync(ingredientToUpdate, "ingredient", i => i.Name))
            {
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool FruitExists(int id)
        {
            return ctx.Ingredients.Any(e => e.Id == id);
        }
    }
}