using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosUTN
{
    public class Inscripciones
    {
        [Key]public int IdInscripcion { get; set; }


        [ForeignKey("IdEvento")]        // Clave foranea
        public int IdEvento { get; set; }       // Clave foranea

        [ForeignKey("IdParticipante")]
        public int IdParticipante { get; set; }

        
        public DateTime FechaInscripcion { get; set; }
        
        public String Estado { get; set; } // Puede ser "Pendiente", "Confirmada" o "Cancelada"


        // Navegacion
        public Eventos? Evento { get; set; }

        public Participantes? Participante { get; set; }
    }
}
