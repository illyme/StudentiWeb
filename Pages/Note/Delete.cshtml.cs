using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentiWeb.Data;
using StudentiWeb.Models;

namespace StudentiWeb.Pages.Note
{
    public class DeleteModel : PageModel
    {
        private readonly StudentiWeb.Data.StudentiWebContext _context;

        public DeleteModel(StudentiWeb.Data.StudentiWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nota Nota { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nota = await _context.Nota
                .Include(n => n.Disciplina)
                .Include(n => n.Student).FirstOrDefaultAsync(m => m.ID == id);

            if (Nota == null)
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

            Nota = await _context.Nota.FindAsync(id);

            if (Nota != null)
            {
                _context.Nota.Remove(Nota);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
