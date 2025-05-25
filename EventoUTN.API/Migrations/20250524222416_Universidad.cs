using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventoUTN.API.Migrations
{
    /// <inheritdoc />
    public partial class Universidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdInscripcion = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Monto = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    InscripcionesIdInscripcion = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripciones_InscripcionesIdInscripcion",
                        column: x => x.InscripcionesIdInscripcion,
                        principalTable: "Inscripciones",
                        principalColumn: "IdInscripcion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionesIdInscripcion",
                table: "Pagos",
                column: "InscripcionesIdInscripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");
        }
    }
}
