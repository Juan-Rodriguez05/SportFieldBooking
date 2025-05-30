using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportFieldBooking.Migrations
{
    /// <inheritdoc />
    public partial class tablasfic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Campos_CampoIdCampo",
                table: "Eventos");

            migrationBuilder.AlterColumn<int>(
                name: "CampoIdCampo",
                table: "Eventos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdCampo",
                table: "Eventos",
                column: "IdCampo");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Campos_CampoIdCampo",
                table: "Eventos",
                column: "CampoIdCampo",
                principalTable: "Campos",
                principalColumn: "IdCampo");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Campos_IdCampo",
                table: "Eventos",
                column: "IdCampo",
                principalTable: "Campos",
                principalColumn: "IdCampo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Campos_CampoIdCampo",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Campos_IdCampo",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_IdCampo",
                table: "Eventos");

            migrationBuilder.AlterColumn<int>(
                name: "CampoIdCampo",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Campos_CampoIdCampo",
                table: "Eventos",
                column: "CampoIdCampo",
                principalTable: "Campos",
                principalColumn: "IdCampo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
