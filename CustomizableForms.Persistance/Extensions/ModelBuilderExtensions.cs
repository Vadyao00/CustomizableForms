using CustomizableForms.Domain.Entities;
using CustomizableForms.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CustomizableForms.Persistance.Extensions;

public static class ModelBuilderExtensions
    {
        public static void SeedInitialData(this ModelBuilder modelBuilder)
        {
            var adminUser = new User
            {
                Id = Guid.Parse("8E445865-A24D-4543-A6C6-9443D048CDB9"),
                Name = "Admin",
                Email = "admin@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123"),
                IsActive = true,
                PreferredLanguage = "en",
                PreferredTheme = "light"
            };
        
            modelBuilder.Entity<User>().HasData(adminUser);
        
            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                UserId = adminUser.Id,
                RoleId = Guid.Parse("8D04DCE2-969A-435D-BBA4-DF3F325983DC")
            });
            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                UserId = adminUser.Id,
                RoleId = Guid.Parse("2C5E174E-3B0E-446F-86AF-483D56FD7210")
            });
        }
    }