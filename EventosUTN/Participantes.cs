using System.ComponentModel.DataAnnotations;

namespace EventosUTN
{
    public class Participantes
    {
        [Key] public int IdParticipante { get; set; }

        public String Nombre { get; set; }

        public String Dirreccion { get; set; }

        public String Telefono { get; set; }

        public String Genero { get; set; }

        public String Email { get; set; }

        public List<Inscripciones>? Inscripciones { get; set; }
    }

}