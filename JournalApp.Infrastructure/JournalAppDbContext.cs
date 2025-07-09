using JournalApp.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JournalApp.Infrastructure;

public class JournalAppDbContext(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration _configuration = configuration;

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
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