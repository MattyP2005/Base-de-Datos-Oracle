using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventoUTN.API.Migrations
{
    /// <inheritdoc />
    public partial class UTNEventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Pagos",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "PonentesIdPonentes",
                table: "Inscripciones",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    IdCertificado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdInscripcion = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Emitido = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    InscripcionesIdInscripcion = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.IdCertificado);
                    table.ForeignKey(
                        name: "FK_Certificados_Inscripciones_InscripcionesIdInscripcion",
                        column: x => x.InscripcionesIdInscripcion,
                        principalTable: "Inscripciones",
                        principalColumn: "IdInscripcion");
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    IdPonentes = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Especialidad = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefono = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.IdPonentes);
                });

            migrationBuilder.CreateTable(
                name: "EventoPonentes",
                columns: table => new
                {
                    IdEventoPonentes = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdEvento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdPonentes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Confirmacion = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    EventosIdEvento = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    PonentesIdPonentes = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoPonentes", x => x.IdEventoPonentes);
                    table.ForeignKey(
                        name: "FK_EventoPonentes_Eventos_EventosIdEvento",
                        column: x => x.EventosIdEvento,
                        principalTable: "Eventos",
                        principalColumn: "IdEvento");
                    table.ForeignKey(
                        name: "FK_EventoPonentes_Ponentes_PonentesIdPonentes",
                        column: x => x.PonentesIdPonentes,
                        principalTable: "Ponentes",
                        principalColumn: "IdPonentes");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_PonentesIdPonentes",
                table: "Inscripciones",
                column: "PonentesIdPonentes");

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_InscripcionesIdInscripcion",
                table: "Certificados",
                column: "InscripcionesIdInscripcion");

            migrationBuilder.CreateIndex(
                name: "IX_EventoPonentes_EventosIdEvento",
                table: "EventoPonentes",
                column: "EventosIdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_EventoPonentes_PonentesIdPonentes",
                table: "EventoPonentes",
                column: "PonentesIdPonentes");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Ponentes_PonentesIdPonentes",
                table: "Inscripciones",
                column: "PonentesIdPonentes",
                principalTable: "Ponentes",
                principalColumn: "IdPonentes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Ponentes_PonentesIdPonentes",
                table: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "EventoPonentes");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropIndex(
                name: "IX_Inscripciones_PonentesIdPonentes",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "PonentesIdPonentes",
                table: "Inscripciones");

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Pagos",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
