using CustomizableForms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomizableForms.Persistance.Configurations;

public class TemplateAccessConfiguration : IEntityTypeConfiguration<TemplateAccess>
{
    public void Configure(EntityTypeBuilder<TemplateAccess> builder)
    {
        builder.ToTable("TemplateAccesses");

        builder.HasKey(e => e.Id);
            
        builder.Property(e => e.Id)
            .HasColumnName("Id");

        builder.Property(e => e.UserId)
            .IsRequired()
            .HasMaxLength(450);

        builder.HasOne(e => e.Template)
            .WithMany(e => e.AccessList)
            .HasForeignKey(e => e.TemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.User)
            .WithMany(e => e.TemplateAccessList)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.TemplateId);
        builder.HasIndex(e => e.UserId);
        builder.HasIndex(e => new { e.TemplateId, e.UserId }).IsUnique();
    }
}