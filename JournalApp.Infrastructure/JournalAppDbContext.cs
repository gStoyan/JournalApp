using JournalApp.Domain.User;
using JournalApp.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JournalApp.Infrastructure;

public class JournalAppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = DatabaseConfiguration.GetDatabasePath();
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Configure the relations
        // modelBuilder.Entity<U>()
        //     .HasOne(p => p.Category)
        //     .WithMany(c => c.Products)
        //     .HasForeignKey(p => p.CategoryId);
        //
        // //Configure additional columns
        // modelBuilder
        //     .Entity<Product>()
        //     .Property(p => p.Status)
        //     .IsRequired()
        //     .HasDefaultValue("Active");
    }
}