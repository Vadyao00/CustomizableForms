using CustomizableForms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomizableForms.Persistance.Configurations;

public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("Templates");

            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Description)
                .HasColumnType("text");

            builder.Property(e => e.Topic)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ImageUrl)
                .HasMaxLength(500);

            builder.Property(e => e.IsPublic)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.HasOne(e => e.User)
                .WithMany(e => e.Templates)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.UserId);
            builder.HasIndex(e => e.IsPublic);
            builder.HasIndex(e => e.Topic);
        }
    }