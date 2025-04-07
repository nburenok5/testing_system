using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp3.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("FullName")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("Login")]
        public string Login { get; set; } = string.Empty;

        [Required]
        [Column("Password")]
        public string Password { get; set; } = string.Empty;

        public List<TestResult> TestResults { get; set; } = new();
    }
}