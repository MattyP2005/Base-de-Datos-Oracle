using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventoUTN.API.Migrations
{
    /// <inheritdoc />
    public partial class v01EventosUTN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Lugar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoEvento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    IdParticipante = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Dirreccion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefono = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.IdParticipante);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdEvento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdParticipante = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EventoIdEvento = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ParticipanteIdParticipante = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.IdInscripcion);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventoIdEvento",
                        column: x => x.EventoIdEvento,
                        principalTable: "Eventos",
                        principalColumn: "IdEvento");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Participantes_ParticipanteIdParticipante",
                        column: x => x.ParticipanteIdParticipante,
                        principalTable: "Participantes",
                        principalColumn: "IdParticipante");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoIdEvento",
                table: "Inscripciones",
                column: "EventoIdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParticipanteIdParticipante",
                table: "Inscripciones",
                column: "ParticipanteIdParticipante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
