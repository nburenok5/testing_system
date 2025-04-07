using System.ComponentModel.DataAnnotations.Schema;
using BlazorApp3.Models;
public class QuestionModel
{
    public int Id { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    
    // Храним все варианты в одном поле (как в базе)
    public string Options { get; set; } = string.Empty;
    
    [NotMapped]
    public List<string> OptionsList
    {
        get => Options.Split('|').ToList(); // Разделитель |
        set => Options = string.Join("|", value);
    }
    
    public int CorrectAnswerIndex { get; set; }
    public int TestModelId { get; set; }
    public TestModel? Test { get; set; }
}