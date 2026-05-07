using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_smarties.Data;
using Project_smarties.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Project_smarties.Pages.Quiz
{
    public class CreateModel : PageModel
    {
        public SignInManager<IdentityUser> SignInManager { get; set; }

        private readonly Project_smarties.Data.ApplicationDbContext _context;
        
        public int QuestionsAmount = 0;

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "quiz name")]
            public string QuizName { get; set; }

            [Display(Name = "Quiz theme")]
            public string QuizTheme { get; set; }

            [Display(Name = "question")]
            public List<string>? Question { get; set; }

            [Display(Name = "Answer")]
            public List<string>? Answer { get; set; }

            [Display(Name = "Number of questions")]
            //sets a minimum and maximum amount of questions
            [Range(10, 100, ErrorMessage = "quiz must have at least 10 questions")]
            public int QuestionCount { get; set; }
        }

        private readonly UserManager<UserApplicationData> _userManager;
        public CreateModel(Project_smarties.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public QuizApplicationData QuizApplicationData { get; set; } = default!;
        [BindProperty]
        public QuizResultApplicationData QuizResultApplicationData { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //checks if the amount of questions the person stated in the input
            if (Input.Question == null || Input.QuestionCount != Input.Question.Count)
            {
                QuestionsAmount = Input.QuestionCount;
                return Page();
            }

            //makes a new instance where the quizData is stored
            var quiz = new QuizApplicationData()
            {
                QuizId = Guid.NewGuid().ToString(),
                QuizName = Input.QuizName,
                questionCount = Input.QuestionCount,
                QuizTheme = Input.QuizTheme,
                questions = Input.Question,
                answers = Input.Answer
            };

            _context.QuizApplicationData.Add(quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
