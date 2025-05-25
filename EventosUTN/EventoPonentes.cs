using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosUTN
{
    public class EventoPonentes
    {
        [Key] public int IdEventoPonentes { get; set; }


        [ForeignKey("IdEvento")]        // Clave foranea
        public int IdEvento { get; set; }


        [ForeignKey("IdPonentes")]        // Clave foranea
        public int IdPonentes { get; set; }

        public bool Confirmacion { get; set; }

        public Eventos? Eventos { get; set; }

        public Ponentes? Ponentes { get; set; }
    }
}
