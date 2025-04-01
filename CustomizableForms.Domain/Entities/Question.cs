using CustomizableForms.Domain.Enums;

namespace CustomizableForms.Domain.Entities;

public class Question
{
    public int Id { get; set; }
    public int TemplateId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public QuestionType Type { get; set; }
    public int Order { get; set; }
    public bool ShowInResults { get; set; }
    public string Options { get; set; }
        
    public Template Template { get; set; }
    public ICollection<Answer> Answers { get; set; }
    
    public Question()
    {
        Answers = new HashSet<Answer>();
    }
}