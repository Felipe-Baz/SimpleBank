using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simplebank.Migrations
{
    /// <inheritdoc />
    public partial class user_transfer_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Users_FromUserId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Users_ToUserId",
                table: "Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Users_FromUserId",
                table: "Transfers",
                column: "FromUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Users_ToUserId",
                table: "Transfers",
                column: "ToUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Users_FromUserId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Users_ToUserId",
                table: "Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Users_FromUserId",
                table: "Transfers",
                column: "FromUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Users_ToUserId",
                table: "Transfers",
                column: "ToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
