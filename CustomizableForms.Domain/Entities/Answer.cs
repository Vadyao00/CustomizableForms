namespace CustomizableForms.Domain.Entities;

public class Answer
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public int QuestionId { get; set; }
    public string Value { get; set; }
        
    public virtual Form Form { get; set; }
    public virtual Question Question { get; set; }
}