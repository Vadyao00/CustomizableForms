namespace CustomizableForms.Domain.Entities;

public class Like
{
    public int Id { get; set; } //не исп в бд (в кофигурации игнор)
    public int TemplateId { get; set; }
    public string UserId { get; set; }
        
    public virtual Template Template { get; set; }
    public virtual User User { get; set; }
}