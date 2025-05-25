using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosUTN
{
    public class Ponentes
    {
        [Key] public int IdPonentes { get; set; }

        public String Nombre { get; set; }

        public String Especialidad { get; set; }

        public String Telefono { get; set; }

        public String Genero { get; set; }

        public String Email { get; set; }

        public List<Inscripciones>? Inscripciones { get; set; }
    }
}
