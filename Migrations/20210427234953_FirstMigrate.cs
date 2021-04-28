using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TriviaProject.Migrations
{
    public partial class FirstMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duels",
                columns: table => new
                {
                    DuelId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId1UserId = table.Column<int>(nullable: true),
                    UserId2UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duels", x => x.DuelId);
                    table.ForeignKey(
                        name: "FK_Duels_Users_UserId1UserId",
                        column: x => x.UserId1UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duels_Users_UserId2UserId",
                        column: x => x.UserId2UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duels_UserId1UserId",
                table: "Duels",
                column: "UserId1UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Duels_UserId2UserId",
                table: "Duels",
                column: "UserId2UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duels");
        }
    }
}
