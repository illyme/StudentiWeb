using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentiWeb.Models
{
    public class Student
    {
        public int ID { get; set; }
        
        [Display(Name = "Nume student")]
        public string Nume { get; set; }
        public string Prenume { get; set; }
        
        [Column(TypeName = "decimal(6,0)")]
        public decimal NrMatricol { get; set; }
    }
}
