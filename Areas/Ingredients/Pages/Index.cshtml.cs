#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealsPlanning.Data;
using MealsPlanning.Models;

namespace MealsPlanning.Areas.Ingredients.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IList<Ingredient> Ingredients { get;set; }

        public async Task OnGetAsync()
        {
            Ingredients = await ctx.Ingredients.ToListAsync();
        }
    }
}