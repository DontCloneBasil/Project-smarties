using System.ComponentModel.DataAnnotations;

namespace Project_smarties.Models
{
    public class LeaderboardsApplicationData
    {
        [Key]
        [Required]
        public string? LeaderboardId { get; set; }
        [Required]
        public string? QuizID { get; set; }
        public List<string>? UserID { get; set; }
    }
}
