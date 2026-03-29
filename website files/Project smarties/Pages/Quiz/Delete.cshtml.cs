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
    public class DeleteModel : PageModel
    {
        private readonly Project_smarties.Data.ApplicationDbContext _context;

        public DeleteModel(Project_smarties.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizapplicationdata = await _context.QuizApplicationData.FindAsync(id);
            if (quizapplicationdata != null)
            {
                QuizApplicationData = quizapplicationdata;
                _context.QuizApplicationData.Remove(QuizApplicationData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
