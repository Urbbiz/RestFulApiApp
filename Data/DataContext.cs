using Microsoft.EntityFrameworkCore;
using RestFulApiApp.Models;

namespace RestFulApiApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
         
        public DbSet<Dish>?  Dishes { get; set; }
        public DbSet<Fruit>? Fruits { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
    }
}
