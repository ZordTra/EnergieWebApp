using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergieWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrationaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: true),
                    HouseholdId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountDatas_DayDatas_DayId",
                        column: x => x.DayId,
                        principalTable: "DayDatas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDatas_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDatas_DayId",
                table: "AccountDatas",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDatas_HouseholdId",
                table: "AccountDatas",
                column: "HouseholdId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountDatas");
        }
    }
}
