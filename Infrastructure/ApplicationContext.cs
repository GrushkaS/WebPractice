using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        internal DbSet<Categories>? Categories { get; set; }
        internal DbSet<Products>? Products { get; set; }

        internal ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string? connection = ConfigurationManager.AppSettings.Get("con_0");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Webpractice;Trusted_Connection=True;");
        }
    }
}