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

namespace StudentiWeb.Pages.Discipline
{
    public class EditModel : PageModel
    {
        private readonly StudentiWeb.Data.StudentiWebContext _context;

        public EditModel(StudentiWeb.Data.StudentiWebContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Disciplina).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }


            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaExists(Disciplina.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            catch (DbUpdateException se)
            {
                if (se.InnerException.Message.Contains("IX_Disciplina_Nume"))
                {
                    this.ModelState.AddModelError("", "Numele disciplinei trebuie sa fie unic");
                    return await OnGetAsync(Disciplina.ID);
                }
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplina.Any(e => e.ID == id);
        }
    }
}
