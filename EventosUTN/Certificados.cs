using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosUTN
{
    public class Certificados
    {
        [Key] public int IdCertificado { get; set; }


        [ForeignKey("IdInscripcion")]        // Clave foranea
        public int IdInscripcion { get; set; }


        public bool Emitido { get; set; }


        // Navegacion
        public Inscripciones? Inscripciones { get; set; }
    }
}
