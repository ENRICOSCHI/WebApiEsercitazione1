using Microsoft.EntityFrameworkCore;
using WebApiEsercitazione1.Models;
namespace WebApiEsercitazione1.Data
{
    public class LbroDbContext : DbContext
    {
        public LbroDbContext(DbContextOptions<LbroDbContext> options) : base(options) { }
        public DbSet<libro> libri { get; set; }
    }

   
}
