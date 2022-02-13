using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitsTraceabilitySystem.Service.DataAccess.Migrations
{
    public partial class addPackangingToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packangings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    ProductSortingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packangings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packangings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Packangings_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Packangings_Sortings_ProductSortingId",
                        column: x => x.ProductSortingId,
                        principalTable: "Sortings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packangings_PackageId",
                table: "Packangings",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Packangings_ProductSortingId",
                table: "Packangings",
                column: "ProductSortingId");

            migrationBuilder.CreateIndex(
                name: "IX_Packangings_UserId",
                table: "Packangings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packangings");
        }
    }
}
