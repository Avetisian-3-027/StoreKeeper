using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.Models;

namespace StoreKeeper.Data.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }

        public static void InitializeDatabase(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var admin = new User
                {
                    Username = "Адміністратор",
                    PasswordHash = null,
                    IsAdmin = true,
                    PermissionsList = null
                };
                context.Users.Add(admin);
                context.SaveChanges();
            }
        }
    }
}