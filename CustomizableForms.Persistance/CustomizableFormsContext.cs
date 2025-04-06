using CustomizableForms.Domain.Entities;
using CustomizableForms.Persistance.Configurations;
using CustomizableForms.Persistance.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomizableForms.Persistance;

public class CustomizableFormsContext : DbContext
{
    public CustomizableFormsContext()
    { }

    public CustomizableFormsContext(DbContextOptions<CustomizableFormsContext> options)
        : base(options)
    { }
    
    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
            
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        modelBuilder.SeedInitialData();
    }
}