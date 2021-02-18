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

        public DbSet<StudentiWeb.Models.Student> Student { get; set; }
    }
}
