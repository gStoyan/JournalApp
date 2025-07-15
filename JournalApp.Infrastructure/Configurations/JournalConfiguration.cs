using JournalApp.Domain.Journal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JournalApp.Infrastructure.Configurations;

public class JournalConfiguration : IEntityTypeConfiguration<Journal>
{
    public void Configure(EntityTypeBuilder<Journal> builder)
    {
        builder.HasKey(j => j.Id);
        builder.Property(j => j.Id)
            .ValueGeneratedOnAdd();

        builder.Property(j => j.Content)
            .IsRequired();

        builder.HasOne(j => j.User)
            .WithMany(u => u.Journals)
            .HasForeignKey(j => j.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}