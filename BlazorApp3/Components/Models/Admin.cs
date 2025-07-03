using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp3.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Column("subject")]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [Column("login")]
        public string Login { get; set; } = string.Empty;

        [Required]
        [Column("password")]
        public string Password { get; set; } = string.Empty;
    }

}