﻿namespace CustomizableForms.Domain.Entities;

public class Template
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Topic { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public User User { get; set; }
    public ICollection<Question> Questions { get; set; }
    public ICollection<Form> Forms { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<TemplateAccess> AccessList { get; set; }
    public ICollection<TemplateTag> Tags { get; set; }
    
    public Template()
    {
        Questions = new HashSet<Question>();
        Forms = new HashSet<Form>();
        Comments = new HashSet<Comment>();
        Likes = new HashSet<Like>();
        AccessList = new HashSet<TemplateAccess>();
        Tags = new HashSet<TemplateTag>();
    }
}