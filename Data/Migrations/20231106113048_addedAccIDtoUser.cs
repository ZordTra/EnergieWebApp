using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergieWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedAccIDtoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDatas_User_UserId",
                table: "AccountDatas");

            migrationBuilder.DropIndex(
                name: "IX_AccountDatas_UserId",
                table: "AccountDatas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AccountDatas");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountId",
                table: "User",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_AccountDatas_AccountId",
                table: "User",
                column: "AccountId",
                principalTable: "AccountDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AccountDatas_AccountId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AccountId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AccountDatas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountDatas_UserId",
                table: "AccountDatas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDatas_User_UserId",
                table: "AccountDatas",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
