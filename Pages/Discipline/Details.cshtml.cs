using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentiWeb.Data;
using StudentiWeb.Models;

namespace StudentiWeb.Pages.Discipline
{
    public class DetailsModel : PageModel
    {
        private readonly StudentiWeb.Data.StudentiWebContext _context;

        public DetailsModel(StudentiWeb.Data.StudentiWebContext context)
        {
            _context = context;
        }

        public Disciplina Disciplina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Disciplina = await _context.Disciplina.FirstOrDefaultAsync(m => m.ID == id);

            if (Disciplina == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
