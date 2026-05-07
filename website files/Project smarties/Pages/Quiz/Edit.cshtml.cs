using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_smarties.Data;
using Project_smarties.Models;

namespace Project_smarties.Pages.Quiz
{
    public class EditModel : PageModel
    {
        private readonly Project_smarties.Data.ApplicationDbContext _context;

        public EditModel(Project_smarties.Data.ApplicationDbContext context)
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

            var quizapplicationdata =  await _context.QuizApplicationData.FirstOrDefaultAsync(m => m.QuizId == id);
            if (quizapplicationdata == null)
            {
                return NotFound();
            }
            QuizApplicationData = quizapplicationdata;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(QuizApplicationData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizApplicationDataExists(QuizApplicationData.QuizId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuizApplicationDataExists(string id)
        {
            return _context.QuizApplicationData.Any(e => e.QuizId == id);
        }
    }
}
