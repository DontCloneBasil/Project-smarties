using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_smarties.Data;
using Project_smarties.Models;

namespace Project_smarties.Pages.Quiz
{
    public class DetailsModel : PageModel
    {
        private readonly Project_smarties.Data.ApplicationDbContext _context;

        public DetailsModel(Project_smarties.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public QuizApplicationData QuizApplicationData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizapplicationdata = await _context.QuizApplicationData.FirstOrDefaultAsync(m => m.QuizId == id);
            if (quizapplicationdata == null)
            {
                return NotFound();
            }
            else
            {
                QuizApplicationData = quizapplicationdata;
            }
            return Page();
        }
    }
}
