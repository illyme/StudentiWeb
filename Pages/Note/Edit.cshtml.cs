using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentiWeb.Data;
using StudentiWeb.Models;

namespace StudentiWeb.Pages.Note
{
    public class EditModel : PageModel
    {
        private readonly StudentiWeb.Data.StudentiWebContext _context;

        public EditModel(StudentiWeb.Data.StudentiWebContext context)
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
           ViewData["DisciplinaID"] = new SelectList(_context.Disciplina, "ID", "Nume");
           ViewData["StudentID"] = new SelectList(_context.Student, "ID", "NumeSiPrenume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Nota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaExists(Nota.ID))
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

        private bool NotaExists(int id)
        {
            return _context.Nota.Any(e => e.ID == id);
        }
    }
}
