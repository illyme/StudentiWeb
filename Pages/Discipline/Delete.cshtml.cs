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
    public class DeleteModel : PageModel
    {
        private readonly StudentiWeb.Data.StudentiWebContext _context;

        public DeleteModel(StudentiWeb.Data.StudentiWebContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Disciplina = await _context.Disciplina.FindAsync(id);

            if (Disciplina != null)
            {
                _context.Disciplina.Remove(Disciplina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
