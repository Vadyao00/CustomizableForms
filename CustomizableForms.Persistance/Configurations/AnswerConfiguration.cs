using CustomizableForms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomizableForms.Persistance.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers");

        builder.HasKey(e => e.Id);
            
        builder.Property(e => e.Id)
            .HasColumnName("Id");

        builder.Property(e => e.Value)
            .IsRequired()
            .HasColumnType("text");

        builder.HasOne(e => e.Form)
            .WithMany(e => e.Answers)
            .HasForeignKey(e => e.FormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Question)
            .WithMany(e => e.Answers)
            .HasForeignKey(e => e.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.FormId);
        builder.HasIndex(e => e.QuestionId);
        builder.HasIndex(e => new { e.FormId, e.QuestionId }).IsUnique();
    }
}