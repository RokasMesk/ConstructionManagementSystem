using Construction.Models;
using Microsoft.EntityFrameworkCore;

namespace Construction.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Worker> Workers { get; set; }
    }
}
