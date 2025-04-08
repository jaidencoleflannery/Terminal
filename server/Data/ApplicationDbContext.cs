using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.UsersModel;
using Models.MessagesModel;
using Models.ConversationsModel;

namespace Data;
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>()
                .HasMany(u => u.Conversations)
                .WithOne(c => c.Users)
                .HasForeignKey(c => c.UsersId)
                .OnDelete(DeleteBehavior.Cascade); // optional: defines what happens on user deletion
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Conversations> Conversations { get; set; }
    }