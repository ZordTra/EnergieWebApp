using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergieWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class deviceAangepast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Modes_ModeId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "Modes");

            migrationBuilder.DropIndex(
                name: "IX_Devices_ModeId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ModeId",
                table: "Devices");

            migrationBuilder.AddColumn<int>(
                name: "Kwh",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Mode",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kwh",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "Devices");

            migrationBuilder.AddColumn<int>(
                name: "ModeId",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Modes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kwh = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ModeId",
                table: "Devices",
                column: "ModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Modes_ModeId",
                table: "Devices",
                column: "ModeId",
                principalTable: "Modes",
                principalColumn: "Id");
        }
    }
}
