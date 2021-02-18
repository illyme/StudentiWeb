﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly StudentiWeb.Data.StudentiWebContext _context;

        public IndexModel(StudentiWeb.Data.StudentiWebContext context)
        {
            _context = context;
        }

        public IList<Nota> Nota { get;set; }

        public async Task OnGetAsync()
        {
            Nota = await _context.Nota
                .Include(n => n.Disciplina)
                .Include(n => n.Student).ToListAsync();
        }
    }
}
