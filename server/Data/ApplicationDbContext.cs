using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Sources> Sources { get; set; }
        public DbSet<Summaries> Summaries { get; set; }
    }
