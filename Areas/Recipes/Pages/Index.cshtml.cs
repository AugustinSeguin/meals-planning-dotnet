#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealsPlanning.Data;
using MealsPlanning.Models;

namespace MealsPlanning.Areas.Recipes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IList<Recipe> Recipes { get;set; }

        public async Task OnGetAsync()
        {
            Recipes = await ctx.Recipes.ToListAsync();
        }
    }
}