using JournalApp.Domain.Journal;
using JournalApp.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace JournalApp.Infrastructure;

public class JournalAppDbContext(DbContextOptions<JournalAppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Journal> Journals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            "Data Source=/Users/sgrancharov/dev/dotnet/JournalApp/JournalApp/JournalApp.Infrastructure/JournalApp.db");
        base.OnConfiguring(optionsBuilder);
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