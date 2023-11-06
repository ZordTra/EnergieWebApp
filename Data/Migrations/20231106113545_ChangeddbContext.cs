using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergieWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeddbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AccountDatas_AccountId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_DayDatas_User_AccountId",
                table: "DayDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_User_AccountDatas_AccountId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Households_HouseholdId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountDatas",
                table: "AccountDatas");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "Admins");

            migrationBuilder.RenameTable(
                name: "AccountDatas",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_User_HouseholdId",
                table: "Users",
                newName: "IX_Users_HouseholdId");

            migrationBuilder.RenameIndex(
                name: "IX_User_AccountId",
                table: "Users",
                newName: "IX_Users_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_AccountId",
                table: "Admins",
                newName: "IX_Admins_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Accounts_AccountId",
                table: "Admins",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayDatas_Users_AccountId",
                table: "DayDatas",
                column: "AccountId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Households_HouseholdId",
                table: "Users",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Accounts_AccountId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_DayDatas_Users_AccountId",
                table: "DayDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Households_HouseholdId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admin");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "AccountDatas");

            migrationBuilder.RenameIndex(
                name: "IX_Users_HouseholdId",
                table: "User",
                newName: "IX_User_HouseholdId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AccountId",
                table: "User",
                newName: "IX_User_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_AccountId",
                table: "Admin",
                newName: "IX_Admin_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountDatas",
                table: "AccountDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AccountDatas_AccountId",
                table: "Admin",
                column: "AccountId",
                principalTable: "AccountDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayDatas_User_AccountId",
                table: "DayDatas",
                column: "AccountId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_AccountDatas_AccountId",
                table: "User",
                column: "AccountId",
                principalTable: "AccountDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Households_HouseholdId",
                table: "User",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
