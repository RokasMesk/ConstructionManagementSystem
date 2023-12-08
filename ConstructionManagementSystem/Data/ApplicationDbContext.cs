using ConstructionManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Worker> Workers { get; set; }
    }
}
