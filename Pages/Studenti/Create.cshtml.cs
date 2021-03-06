﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentiWeb.Data;
using StudentiWeb.Models;

namespace StudentiWeb.Pages.Studenti
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
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException se)
            {
                if (se.InnerException.Message.Contains("IX_Student_NrMatricol"))
                {
                    this.ModelState.AddModelError("", "Numarul matricol trebuie sa fie unic");
                    return OnGet();
                }
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
