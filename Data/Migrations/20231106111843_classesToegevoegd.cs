using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergieWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class classesToegevoegd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDatas_DayDatas_DayId",
                table: "AccountDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountDatas_Households_HouseholdId",
                table: "AccountDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Households_HouseholdId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_HouseholdId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_AccountDatas_HouseholdId",
                table: "AccountDatas");

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "AccountDatas");

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "AccountDatas");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AccountDatas",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "DayId",
                table: "AccountDatas",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountDatas_DayId",
                table: "AccountDatas",
                newName: "IX_AccountDatas_UserId");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "DayDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "DayDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AccountDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_AccountDatas_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayDataDevice",
                columns: table => new
                {
                    DayDatasId = table.Column<int>(type: "int", nullable: false),
                    DevicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayDataDevice", x => new { x.DayDatasId, x.DevicesId });
                    table.ForeignKey(
                        name: "FK_DayDataDevice_DayDatas_DayDatasId",
                        column: x => x.DayDatasId,
                        principalTable: "DayDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayDataDevice_Devices_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceHousehold",
                columns: table => new
                {
                    DevicesId = table.Column<int>(type: "int", nullable: false),
                    HouseholdsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceHousehold", x => new { x.DevicesId, x.HouseholdsId });
                    table.ForeignKey(
                        name: "FK_DeviceHousehold_Devices_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceHousehold_Households_HouseholdsId",
                        column: x => x.HouseholdsId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseholdId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayDatas_AccountId",
                table: "DayDatas",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AccountId",
                table: "Admin",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayDataDevice_DevicesId",
                table: "DayDataDevice",
                column: "DevicesId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceHousehold_HouseholdsId",
                table: "DeviceHousehold",
                column: "HouseholdsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_HouseholdId",
                table: "User",
                column: "HouseholdId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDatas_User_UserId",
                table: "AccountDatas",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayDatas_User_AccountId",
                table: "DayDatas",
                column: "AccountId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDatas_User_UserId",
                table: "AccountDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_DayDatas_User_AccountId",
                table: "DayDatas");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "DayDataDevice");

            migrationBuilder.DropTable(
                name: "DeviceHousehold");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_DayDatas_AccountId",
                table: "DayDatas");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "DayDatas");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "DayDatas");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AccountDatas");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AccountDatas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AccountDatas",
                newName: "DayId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountDatas_UserId",
                table: "AccountDatas",
                newName: "IX_AccountDatas_DayId");

            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "AccountDatas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "AccountDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_HouseholdId",
                table: "Devices",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDatas_HouseholdId",
                table: "AccountDatas",
                column: "HouseholdId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDatas_DayDatas_DayId",
                table: "AccountDatas",
                column: "DayId",
                principalTable: "DayDatas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDatas_Households_HouseholdId",
                table: "AccountDatas",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Households_HouseholdId",
                table: "Devices",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id");
        }
    }
}
