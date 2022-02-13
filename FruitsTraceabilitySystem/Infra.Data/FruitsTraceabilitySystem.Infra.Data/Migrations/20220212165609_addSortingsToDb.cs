using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitsTraceabilitySystem.Service.DataAccess.Migrations
{
    public partial class addSortingsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sortings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarvestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sortings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sortings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sortings_Harvests_HarvestId",
                        column: x => x.HarvestId,
                        principalTable: "Harvests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sortings_HarvestId",
                table: "Sortings",
                column: "HarvestId");

            migrationBuilder.CreateIndex(
                name: "IX_Sortings_UserId",
                table: "Sortings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sortings");
        }
    }
}
