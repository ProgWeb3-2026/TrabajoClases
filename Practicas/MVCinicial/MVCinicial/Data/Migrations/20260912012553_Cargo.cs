using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCinicial.Data.Migrations
{
    /// <inheritdoc />
    public partial class Cargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCargo",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.IdCargo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdCargo",
                table: "Empleado",
                column: "IdCargo");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Cargo_IdCargo",
                table: "Empleado",
                column: "IdCargo",
                principalTable: "Cargo",
                principalColumn: "IdCargo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Cargo_IdCargo",
                table: "Empleado");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_IdCargo",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "IdCargo",
                table: "Empleado");
        }
    }
}
