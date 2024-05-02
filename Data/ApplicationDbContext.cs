using Microsoft.EntityFrameworkCore;
using MealsPlanning.Models.Ingredients;
using MealsPlanning.Models.Recipes;

namespace MealsPlanning.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
    }
}