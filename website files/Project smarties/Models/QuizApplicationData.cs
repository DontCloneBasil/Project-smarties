using System.ComponentModel.DataAnnotations;

namespace Project_smarties.Models
{
    public class QuizApplicationData
    {
        [Key]
        [Required]
        public string? QuizId { get; set; }
        [Required]
        public string? QuizName { get; set; }
        [Required]
        public string? QuizTheme { get; set; }
        [Required]
        public int questionCount { get; set; }
        [Required]
        public List<string>? questions { get; set; }
        [Required]
        public List<string>? answers { get; set; }
    }
}
