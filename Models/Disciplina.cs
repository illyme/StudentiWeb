using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentiWeb.Models
{
    public class Disciplina
    {
        public int ID { get; set; }

        [Display(Name = "Nume disciplina")]
        public string Nume { get; set; }
        
        public string Cod { get; set; }

        public ICollection<Nota> Note { get; set; }
    }
}
