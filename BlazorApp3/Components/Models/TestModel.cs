namespace BlazorApp3.Models
{
    public class TestModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public List<QuestionModel> Questions { get; set; } = new();
    }
}