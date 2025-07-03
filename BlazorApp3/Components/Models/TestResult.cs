using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp3.Models
{
    public class TestResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("test_id")] // Явно указываем имя столбца
        public int TestId { get; set; }

        public TestModel? Test { get; set; }

        [Required]
        [Column("student_id")] // Явно указываем имя столбца
        public int StudentId { get; set; }

        public Student? Student { get; set; }

        [Required]
        [Range(0, 100)]
        [Column("result")]
        public int Score { get; set; }

        [Required]
        [Column("date_taken")]
        public string DateTaken { get; set; } = string.Empty;

        [Required]
        [Column("time_taken")]
        public string TimeTaken { get; set; } = string.Empty;
    }
}