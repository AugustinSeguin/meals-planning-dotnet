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

namespace MealsPlanning.Areas.Recipes.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext ctx;

        public EditModel(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await ctx.Recipes
                .AsNoTracking()
                .Include(r => r.RecipeIngredient)
                    .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (Recipe == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var recipeToUpdate = await ctx.Recipes
                .FirstOrDefaultAsync(f => f.Id == id);

            if (recipeToUpdate == null)
                return NotFound();

            if (await TryUpdateModelAsync(recipeToUpdate, "recipe", r => r.Name, r => r.Level, r => r.NbMeals, r => r.Instructions))
            {
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool FruitExists(int id)
        {
            return ctx.Recipes.Any(e => e.Id == id);
        }
    }
}