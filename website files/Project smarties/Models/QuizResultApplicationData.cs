using System.ComponentModel.DataAnnotations;

namespace Project_smarties.Models
{
    public class QuizResultApplicationData
    {
        [Key]
        [Required]
        public string? QuizResultID { get; set; }
        [Required]
        public string? CompletedQuizName { get; set; }
        [Required]
        public string? UserID { get; set; }
        public int HighScore { get; set; }
        public int TotalAttempts { get; set; }
        public float HighScoreTime { get; set; }
    }
}
