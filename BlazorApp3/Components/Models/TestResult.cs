using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp3.Models
{
    public class TestResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("TestModel")]
        public int TestId { get; set; }
        public TestModel? Test { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        [Range(0, 100)]
        public int Score { get; set; }

        [Required]
        public DateTime TestDate { get; set; } = DateTime.Now;
    }
}