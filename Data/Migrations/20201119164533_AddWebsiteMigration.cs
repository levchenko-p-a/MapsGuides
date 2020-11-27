using Microsoft.EntityFrameworkCore.Migrations;

namespace MapsGuides.Data.Migrations
{
    public partial class AddWebsiteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumb",
                table: "Dots");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Dots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Dots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Dots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Dots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Dots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbFile",
                table: "Dots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbName",
                table: "Dots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Dots",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "ThumbFile",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "ThumbName",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Dots");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Thumb",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
