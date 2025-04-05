using Microsoft.AspNetCore.Identity;

namespace CustomizableForms.Domain.Entities;

public class User : IdentityUser
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Name { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public string PreferredLanguage { get; set; } = "en";
    public string PreferredTheme { get; set; } = "light";
        
    public virtual ICollection<Template> Templates { get; set; }
    public virtual ICollection<Form> Forms { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<TemplateAccess> TemplateAccessList { get; set; }
    
    public User()
    {
        Templates = new HashSet<Template>();
        Forms = new HashSet<Form>();
        Comments = new HashSet<Comment>();
        Likes = new HashSet<Like>();
        TemplateAccessList = new HashSet<TemplateAccess>();
    }
}