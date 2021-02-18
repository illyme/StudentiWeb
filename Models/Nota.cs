using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentiWeb.Models
{
    public class Nota
    {
        public int ID { get; set; }
        
        public int StudentID { get; set; }

        public int DisciplinaID { get; set; }

        [Column (TypeName = "decimal(4,2)")]
        public decimal Valoare_nota{ get; set; }

        public Student Student { get; set; }

        public Disciplina Disciplina { get; set; }


    }
}
