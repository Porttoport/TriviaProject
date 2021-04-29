using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TriviaProject.Migrations
{
    public partial class ThirdMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "User1Id",
                table: "Duels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User2Id",
                table: "Duels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ResultId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    difficulty = table.Column<string>(nullable: true),
                    question = table.Column<string>(nullable: true),
                    correct_answer = table.Column<string>(nullable: true),
                    DuelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Result_Duels_DuelId",
                        column: x => x.DuelId,
                        principalTable: "Duels",
                        principalColumn: "DuelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duels_User1Id",
                table: "Duels",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Duels_User2Id",
                table: "Duels",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Result_DuelId",
                table: "Result",
                column: "DuelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duels_Users_User1Id",
                table: "Duels",
                column: "User1Id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Duels_Users_User2Id",
                table: "Duels",
                column: "User2Id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duels_Users_User1Id",
                table: "Duels");

            migrationBuilder.DropForeignKey(
                name: "FK_Duels_Users_User2Id",
                table: "Duels");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Duels_User1Id",
                table: "Duels");

            migrationBuilder.DropIndex(
                name: "IX_Duels_User2Id",
                table: "Duels");

            migrationBuilder.DropColumn(
                name: "User1Id",
                table: "Duels");

            migrationBuilder.DropColumn(
                name: "User2Id",
                table: "Duels");

            migrationBuilder.AddColumn<int>(
                name: "User1UserId",
                table: "Duels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User2UserId",
                table: "Duels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Duels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId2",
                table: "Duels",
                type: "int",
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
    }
}
