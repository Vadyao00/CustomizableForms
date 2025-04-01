namespace CustomizableForms.Domain.Entities;

public class Form
{
    public int Id { get; set; }
    public int TemplateId { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
        
    public virtual Template Template { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Answer> Answers { get; set; }
    
    public Form()
    {
        Answers = new HashSet<Answer>();
    }
}