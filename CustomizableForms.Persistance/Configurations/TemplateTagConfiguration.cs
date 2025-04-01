using CustomizableForms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomizableForms.Persistance.Configurations;

public class TemplateTagConfiguration : IEntityTypeConfiguration<TemplateTag>
{
    public void Configure(EntityTypeBuilder<TemplateTag> builder)
    {
        builder.ToTable("TemplateTags");

        builder.HasKey(e => new { e.TemplateId, e.TagId });

        builder.HasOne(e => e.Template)
            .WithMany(e => e.Tags)
            .HasForeignKey(e => e.TemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Tag)
            .WithMany(e => e.Templates)
            .HasForeignKey(e => e.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.TemplateId);
        builder.HasIndex(e => e.TagId);
    }
}