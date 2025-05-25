using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosUTN
{
    public class Eventos
    {
        [Key] public int IdEvento { get; set; }

        public String Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public String Lugar { get; set; }

        public String TipoEvento { get; set; }
    }
}
