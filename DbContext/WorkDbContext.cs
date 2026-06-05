using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.Models.Work;

namespace StoreKeeper.Data.DbContext
{
    public class WorkDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        public WorkDbContext(DbContextOptions<WorkDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish>()
                .HasIndex(d => d.TechMapNumber)
                .IsUnique();

            modelBuilder.Entity<DishIngredient>()
                .HasIndex(di => new { di.DishId, di.ProductId, di.StartDate, di.EndDate })
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoiceItems)
                .WithOne(ii => ii.Invoice)
                .HasForeignKey(ii => ii.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuditLog>()
                .HasOne(l => l.Invoice)
                .WithMany()
                .HasForeignKey(l => l.InvoiceId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}