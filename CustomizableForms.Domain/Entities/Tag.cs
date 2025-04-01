namespace CustomizableForms.Domain.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
        
    public virtual ICollection<TemplateTag> Templates { get; set; }
    
    public Tag()
    {
        Templates = new HashSet<TemplateTag>();
    }
}