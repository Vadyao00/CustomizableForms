using CustomizableForms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomizableForms.Persistance.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Questions");

        builder.HasKey(e => e.Id);
            
        builder.Property(e => e.Id)
            .HasColumnName("Id");

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Description)
            .HasColumnType("text");

        builder.Property(e => e.Type)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(e => e.Order)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(e => e.ShowInResults)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(e => e.Options)
            .HasColumnType("jsonb");

        builder.HasOne(e => e.Template)
            .WithMany(e => e.Questions)
            .HasForeignKey(e => e.TemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.TemplateId);
        builder.HasIndex(e => new { e.TemplateId, e.Order });
    }
}