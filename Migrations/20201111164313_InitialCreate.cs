using Microsoft.EntityFrameworkCore.Migrations;

namespace DeserializationSample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CATALOGCD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(nullable: true),
                    ARTIST = table.Column<string>(nullable: true),
                    COUNTRY = table.Column<string>(nullable: true),
                    COMPANY = table.Column<string>(nullable: true),
                    PRICE = table.Column<decimal>(nullable: false),
                    YEAR = table.Column<int>(nullable: false),
                    CATALOGId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATALOGCD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CATALOGCD_Catalogs_CATALOGId",
                        column: x => x.CATALOGId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CATALOGCD_CATALOGId",
                table: "CATALOGCD",
                column: "CATALOGId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CATALOGCD");

            migrationBuilder.DropTable(
                name: "Catalogs");
        }
    }
}
