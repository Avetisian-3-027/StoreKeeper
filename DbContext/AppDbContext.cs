using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.Models;
using System.Reflection.Emit;

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
                    CanViewProducts = true,
                    CanEditProducts = true,
                    CanDeleteProducts = true,
                    CanViewDishes = true,
                    CanEditDishes = true,
                    CanDeleteDishes = true,
                    CanCreateInvoices = true,
                    CanPrintInvoices = true,
                    CanManageRoles = true,
                    CanViewLogs = true
                };
                context.Users.Add(admin);
                context.SaveChanges();
            }
        }
    }
}