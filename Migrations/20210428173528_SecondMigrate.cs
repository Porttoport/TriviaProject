using Microsoft.EntityFrameworkCore.Migrations;

namespace TriviaProject.Migrations
{
    public partial class SecondMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duels_Users_UserId1UserId",
                table: "Duels");

            migrationBuilder.DropForeignKey(
                name: "FK_Duels_Users_UserId2UserId",
                table: "Duels");

            migrationBuilder.DropIndex(
                name: "IX_Duels_UserId1UserId",
                table: "Duels");

            migrationBuilder.DropIndex(
                name: "IX_Duels_UserId2UserId",
                table: "Duels");

            migrationBuilder.DropColumn(
                name: "UserId1UserId",
                table: "Duels");

            migrationBuilder.DropColumn(
                name: "UserId2UserId",
                table: "Duels");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User1UserId",
                table: "Duels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User2UserId",
                table: "Duels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Duels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId2",
                table: "Duels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Duels_User1UserId",
                table: "Duels",
                column: "User1UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Duels_User2UserId",
                table: "Duels",
                column: "User2UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duels_Users_User1UserId",
                table: "Duels",
                column: "User1UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Duels_Users_User2UserId",
                table: "Duels",
                column: "User2UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duels_Users_User1UserId",
                table: "Duels");

            migrationBuilder.DropForeignKey(
                name: "FK_Duels_Users_User2UserId",
                table: "Duels");

            migrationBuilder.DropIndex(
                name: "IX_Duels_User1UserId",
                table: "Duels");

            migrationBuilder.DropIndex(
                name: "IX_Duels_User2UserId",
                table: "Duels");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User1UserId",
                table: "Duels");

            migrationBuilder.DropColumn(
                name: "User2UserId",
                table: "Duels");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Duels");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "Duels");

            migrationBuilder.AddColumn<int>(
                name: "UserId1UserId",
                table: "Duels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId2UserId",
                table: "Duels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Duels_UserId1UserId",
                table: "Duels",
                column: "UserId1UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Duels_UserId2UserId",
                table: "Duels",
                column: "UserId2UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duels_Users_UserId1UserId",
                table: "Duels",
                column: "UserId1UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Duels_Users_UserId2UserId",
                table: "Duels",
                column: "UserId2UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
