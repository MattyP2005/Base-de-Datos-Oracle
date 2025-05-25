using EventosUTN.APIConsumer;
using EventosUTN;

namespace EventosUTN.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProbarParticipantes();
            //ProbarEventos();

            Console.ReadLine();
        }

        private static void ProbarParticipantes()
        {
            Crud<Participantes>.EndPoint = "https://localhost:7010/api/Participantes";

            // crear un objeto de la clase libro
            var participante = Crud<Participantes>.Create(new Participantes
            {
                IdParticipante = 0,   // para crear un registro nuevo
                Nombre = "Luis Perez",
                Dirreccion = "Yuyucocha",
                Telefono = "0996699795",
                Genero = "Hombre",
                Email = "luis@gmail.com",
            });


            // obtener todos los libros
            var participantes = Crud<Participantes>.GetAll();

            foreach (var p in participantes)
            {
                Console.WriteLine($"idParticipante: {p.IdParticipante}, Nombre: {p.Nombre}, Dirreccion: {p.Dirreccion}, Telefono: {p.Telefono}, Genero: {p.Genero}, Email: {p.Email} ");
            }
        }

        /*private static void ProbarEventos()
        {
            Crud<Eventos>.EndPoint = "https://localhost:7010/api/Eventos";

            // crear un objeto de la clase Evento
            var evento = Crud<Eventos>.Create(new Eventos
            {
                IdEvento = 0,   // para crear un registro nuevo
                Nombre = "Evento prueba",
                Fecha = new DateTime(2025, 5, 26),
                Lugar = "Auditorio Principal",
                TipoEvento = "Conferencia"
            });


            // obtener todos los Eventos
            var eventos = Crud<Eventos>.GetAll();

            foreach (var e in eventos)
            {
                Console.WriteLine($"idEvento: {e.IdEvento}, Nombre: {e.Nombre}, Fecha: {e.Fecha.ToShortDateString()}, Lugar: {e.Lugar}, TipoEvento: {e.TipoEvento}");
            }
        }

        /*private static void ProbarAutores()
        {
            Crud<Autor>.EndPoint = "https://localhost:7041/api/Autores";
            // crear un objeto de la clase autor
            var autor = Crud<Autor>.Create(new Autor
            {
                Codigo = 0,   // para crear un registro nuevo
                Nombre = "Juan ",
                Apellido = "Lopez",
                FechaNacmiento = new DateTime(1990, 1, 1),
                PaisCodigo = 1
            });

            // actualizar el autor
            autor.Nombre = "Juan Actualizado";
            Crud<Autor>.Update(autor.Codigo, autor);

            // obtener todos los autores
            var autores = Crud<Autor>.GetAll();
            foreach (var a in autores)
            {
                Console.WriteLine($"Codigo: {a.Codigo}, Nombre: {a.Nombre}, Apellido: {a.Apellido}, FechaNacmiento: {a.FechaNacmiento.ToShortDateString()}, PaisCodigo: {a.Pais.Nombre}");
            }
        }

        private static void ProbarEditoriales()
        {
            Crud<Editorial>.EndPoint = "https://localhost:7041/api/Editoriales";

            // crear un objeto de la clase editorial
            var santillana = Crud<Editorial>.Create(new Editorial
            {
                Codigo = 0,   // para crear un registro nuevo
                Nombre = "Santillana 2",
                PaisCodigo = 1
            });

            // actualizar la editorial
            santillana.Nombre = "Santillana 2 Actualizado";
            Crud<Editorial>.Update(santillana.Codigo, santillana);

            // obtener todas las editoriales
            var editoriales = Crud<Editorial>.GetAll();
            foreach (var e in editoriales)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, PaisCodigo: {e.Pais.Nombre}");
            }
        }
    }
}*/
    }
}
