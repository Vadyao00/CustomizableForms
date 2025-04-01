using CustomizableForms.Domain.Entities;
using CustomizableForms.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CustomizableForms.Persistance.Extensions;

public static class ModelBuilderExtensions
    {
        public static void SeedInitialData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Education" },
                new Tag { Id = 2, Name = "Business" },
                new Tag { Id = 3, Name = "Survey" },
                new Tag { Id = 4, Name = "Feedback" },
                new Tag { Id = 5, Name = "Quiz" },
                new Tag { Id = 6, Name = "Test" }
            );
            
            var adminId = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            var adminUser = new User 
            { 
                Id = adminId, 
                UserName = "admin", 
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM", 
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                IsBlocked = false,
                CreatedAt = new DateTime(2023, 1, 1),
                PreferredLanguage = "en",
                PreferredTheme = "light"
            };
            
            var passwordHasher = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin123!");
            
            modelBuilder.Entity<User>().HasData(adminUser);
            
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = adminId
                }
            );
            
            var demoId = "a18be9c0-aa65-4af8-bd17-00bd9344e576";
            var demoUser = new User 
            { 
                Id = demoId, 
                UserName = "demo", 
                NormalizedUserName = "DEMO",
                Email = "demo@example.com",
                NormalizedEmail = "DEMO@EXAMPLE.COM", 
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                IsBlocked = false,
                CreatedAt = new DateTime(2023, 1, 1),
                PreferredLanguage = "en",
                PreferredTheme = "light"
            };
            
            demoUser.PasswordHash = passwordHasher.HashPassword(demoUser, "Demo123!");
            
            modelBuilder.Entity<User>().HasData(demoUser);
            
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = demoId
                }
            );
            
            modelBuilder.Entity<Template>().HasData(new Template
            {
                Id = 1,
                UserId = adminId,
                Title = "Customer Satisfaction Survey",
                Description = "A simple survey to gather feedback from customers about our products and services.",
                Topic = "Feedback",
                IsPublic = true,
                CreatedAt = new DateTime(2023, 1, 2),
                UpdatedAt = new DateTime(2023, 1, 2)
            });
            
            modelBuilder.Entity<TemplateTag>().HasData(
                new { TemplateId = 1, TagId = 3 },
                new { TemplateId = 1, TagId = 4 }
            );
            
            modelBuilder.Entity<Question>().HasData(
                new Question 
                { 
                    Id = 1, 
                    TemplateId = 1, 
                    Title = "How satisfied are you with our product?", 
                    Description = "On a scale of 1 to 5, where 5 is very satisfied",
                    Type = QuestionType.Integer,
                    Order = 0,
                    ShowInResults = true
                },
                new Question 
                { 
                    Id = 2, 
                    TemplateId = 1, 
                    Title = "What aspects of the product do you like most?", 
                    Type = QuestionType.MultiLineText,
                    Order = 1,
                    ShowInResults = true
                },
                new Question 
                { 
                    Id = 3, 
                    TemplateId = 1, 
                    Title = "Would you recommend our product to others?", 
                    Type = QuestionType.Checkbox,
                    Order = 2,
                    ShowInResults = true
                },
                new Question 
                { 
                    Id = 4, 
                    TemplateId = 1, 
                    Title = "Your email for further contact", 
                    Type = QuestionType.SingleLineText,
                    Order = 3,
                    ShowInResults = false
                }
            );
        }
    }