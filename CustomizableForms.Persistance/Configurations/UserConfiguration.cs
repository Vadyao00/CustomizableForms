using CustomizableForms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomizableForms.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e => e.IsBlocked)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(e => e.PreferredLanguage)
            .IsRequired()
            .HasMaxLength(10)
            .HasDefaultValue("en");

        builder.Property(e => e.PreferredTheme)
            .IsRequired()
            .HasMaxLength(10)
            .HasDefaultValue("light");

        builder.HasIndex(e => e.UserName)
            .IsUnique();
            
        builder.HasIndex(e => e.NormalizedEmail)
            .HasDatabaseName("EmailIndex");
            
        builder.HasIndex(e => e.NormalizedUserName)
            .HasDatabaseName("UserNameIndex")
            .IsUnique();
                
        builder.ToTable("AspNetUsers");
    }
}