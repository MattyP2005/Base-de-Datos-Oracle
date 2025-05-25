using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventosUTN;

    public class AppContext : DbContext
    {
        public AppContext (DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<EventosUTN.Participantes> Participantes { get; set; } = default!;

        public DbSet<EventosUTN.Inscripciones> Inscripciones { get; set; } = default!;

        public DbSet<EventosUTN.Eventos> Eventos { get; set; } = default!;

        public DbSet<EventosUTN.Pagos> Pagos { get; set; } = default!;

        public DbSet<EventosUTN.Certificados> Certificados { get; set; } = default!;

        public DbSet<EventosUTN.Ponentes> Ponentes { get; set; } = default!;

        public DbSet<EventosUTN.EventoPonentes> EventoPonentes { get; set; } = default!;
    }
