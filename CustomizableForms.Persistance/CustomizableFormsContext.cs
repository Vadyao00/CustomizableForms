using CustomizableForms.Domain.Entities;
using CustomizableForms.Persistance.Configurations;
using CustomizableForms.Persistance.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomizableForms.Persistance;

public class CustomizableFormsContext : IdentityDbContext<User>
{
    public CustomizableFormsContext()
    { }

    public CustomizableFormsContext(DbContextOptions<CustomizableFormsContext> options)
        : base(options)
    { }
    
    public virtual DbSet<Template> Templates { get; set; }
    public virtual DbSet<Question> Questions { get; set; }
    public virtual DbSet<Form> Forms { get; set; }
    public virtual DbSet<Answer> Answers { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Like> Likes { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<TemplateTag> TemplateTags { get; set; }
    public virtual DbSet<TemplateAccess> TemplateAccesses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new FormConfiguration());
        modelBuilder.ApplyConfiguration(new AnswerConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new LikeConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateTagConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateAccessConfiguration());
            
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        //подключение расширения pg_trgm для полнотекстового поиска
        //modelBuilder.HasPostgresExtension("pg_trgm");
            
        modelBuilder.SeedInitialData();
    }
}