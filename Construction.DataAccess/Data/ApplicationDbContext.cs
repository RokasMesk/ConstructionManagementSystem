using Construction.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Construction.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Worker> Workers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Worker>().HasData(
                new Worker { WorkerId =1, Name = "Jhon", LastName= "Piotr", Number = "+37060606060", WorkTitle= "Betonuotojas" },
                new Worker { WorkerId =2, Name = "Matt", LastName= "Snow", Number = "+37067989898", WorkTitle= "Apdailininkas" }
                ) ;
        }
    }
}
