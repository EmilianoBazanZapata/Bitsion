using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CreacionDeLaBaseDeDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Apellido = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Identificacion = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Maneja = table.Column<bool>(type: "bit", nullable: false),
                    UsaLentes = table.Column<bool>(type: "bit", nullable: false),
                    EsDiabetico = table.Column<bool>(type: "bit", nullable: false),
                    PadeceOtraEnfermedad = table.Column<bool>(type: "bit", nullable: false),
                    OtraEnfermedad = table.Column<string>(type: "VARCHAR(5000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
