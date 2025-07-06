using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BlazorApp3.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Column("birth_date")]
        public string BirthDate { get; set; } = string.Empty;

        [Required]
        [Column("login")]
        public string Login { get; set; } = string.Empty;

        [Required]
        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Column("subjects")]
        public string SubjectsString { get; set; } = string.Empty;

        [NotMapped]
        public List<string> Subjects
        {
            get => string.IsNullOrEmpty(SubjectsString) 
                ? new List<string>() 
                : SubjectsString.Split(',').ToList();
            set => SubjectsString = value != null ? string.Join(",", value) : "";
        }

        public List<TestResult> TestResults { get; set; } = new List<TestResult>();
    }
}