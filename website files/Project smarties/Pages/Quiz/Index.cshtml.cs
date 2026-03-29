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
    public class IndexModel : PageModel
    {
        private readonly Project_smarties.Data.ApplicationDbContext _context;

        public IndexModel(Project_smarties.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<QuizApplicationData> QuizApplicationData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            QuizApplicationData = await _context.QuizApplicationData.ToListAsync();
        }
    }
}
