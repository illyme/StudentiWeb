using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentiWeb.Models;

namespace StudentiWeb.Data
{
    public class StudentiWebContext : DbContext
    {
        public StudentiWebContext (DbContextOptions<StudentiWebContext> options)
            : base(options)
        {
        }

        public StudentiWebContext(DbSet<Disciplina> disciplina)
        {
            Disciplina = disciplina;
        }

        public DbSet<StudentiWeb.Models.Student> Student { get; set; }
        public DbSet<StudentiWeb.Models.Disciplina> Disciplina { get; set; }
    }
}
