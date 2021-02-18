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
        public DbSet<StudentiWeb.Models.Nota> Nota { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Nota>().HasIndex(e => new { e.StudentID, e.DisciplinaID }).IsUnique();

            modelBuilder.Entity<Student>().HasIndex(e => e.NrMatricol).IsUnique();

            modelBuilder.Entity<Disciplina>().HasIndex(e => e.Nume).IsUnique();
        }
    }
}
