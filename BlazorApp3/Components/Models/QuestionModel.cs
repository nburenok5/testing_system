using System.ComponentModel.DataAnnotations.Schema;
using BlazorApp3.Models;
using System.ComponentModel.DataAnnotations;

public class QuestionModel
{
    public int Id { get; set; }

    [Required]
    [Column("question_text")] // Явно указываем имя столбца
    public string QuestionText { get; set; } = string.Empty;

    // Все варианты ответов в одной строке, разделённые |
    [Required]
    [Column("answer_options")] // Явно указываем имя столбца
    public string AnswerOptions { get; set; } = string.Empty;

    // Не отображается в БД — используется для удобства
    [NotMapped]
    public List<string> AnswerOptionsList
    {
        get => AnswerOptions.Split('|').ToList();
        set => AnswerOptions = string.Join("|", value);
    }

    // Новый тип: string (может быть "2", "3", "текст" и т.п.)
    [Required]
    [Column("correct_answer")] // Явно указываем имя столбца
    public string CorrectAnswer { get; set; } = string.Empty;

    // Ссылка на тест
    [Column("test_id")] // Явно указываем имя столбца
    public int TestId { get; set; }
    public TestModel? Test { get; set; }
}