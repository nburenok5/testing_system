using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp3.Models
{
    public class StudentTest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("student_id")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [Column("test_id")]
        public int TestId { get; set; }
        public TestModel Test { get; set; }
    }
}