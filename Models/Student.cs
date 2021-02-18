using System.Collections.Generic;
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
        
        public int NrMatricol { get; set; }

        public ICollection<Nota> Note { get; set; }

        public string NumeSiPrenume { get { return Nume + " " + Prenume; } }
    }
}
