using Microsoft.EntityFrameworkCore.Migrations;

namespace MapsGuides.Data.Migrations
{
    public partial class AddDotTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    TimeOpen = table.Column<string>(nullable: true),
                    TimeClose = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Thumb = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dots", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dots");
        }
    }
}
