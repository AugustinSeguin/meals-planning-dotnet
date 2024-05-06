using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealsPlanning.Data;
using MealsPlanning.Models;

namespace MealsPlanning.Areas.Recipes.Pages
{
    public class DetailsModel : PageModel
    {

        private readonly ApplicationDbContext ctx;

        public DetailsModel(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await ctx.Recipes
              .Include(r => r.RecipeIngredient)
                  .ThenInclude(ri => ri.Ingredient)
              .FirstOrDefaultAsync(r => r.Id == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}