using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentiWeb.Data;
using StudentiWeb.Models;

namespace StudentiWeb.Pages.Discipline
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
            return Page();
        }

        [BindProperty]
        public Disciplina Disciplina { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Disciplina.Add(Disciplina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
