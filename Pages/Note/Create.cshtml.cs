using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentiWeb.Data;
using StudentiWeb.Models;

namespace StudentiWeb.Pages.Note
{
    public class CreateModel : PageModel
    {
        private readonly StudentiWeb.Data.StudentiWebContext _context;

        public CreateModel(StudentiWeb.Data.StudentiWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DisciplinaID"] = new SelectList(_context.Disciplina, "ID", "Nume");
        ViewData["StudentID"] = new SelectList(_context.Student, "ID", "NumeSiPrenume");
            return Page();
        }

        [BindProperty]
        public Nota Nota { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Nota.Add(Nota);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException se)
            {
                if (se.InnerException.Message.Contains("IX_Nota_StudentID_DisciplinaID"))
                {
                    this.ModelState.AddModelError("", "Nu putem adauga aceeasi nota de 2 ori");
                    return OnGet();
                }
                throw;
            }


            return RedirectToPage("./Index");
        }
    }
}
