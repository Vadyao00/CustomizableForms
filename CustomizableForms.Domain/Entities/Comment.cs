namespace CustomizableForms.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public int TemplateId { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
        
    public virtual Template Template { get; set; }
    public virtual User User { get; set; }
}