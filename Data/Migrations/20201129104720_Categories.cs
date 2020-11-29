using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MapsGuides.Data.Migrations
{
    public partial class Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "ThumbFile",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "ThumbName",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "TimeClose",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "TimeOpen",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Dots");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Dots",
                newName: "website");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Dots",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Dots",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Dots",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Dots",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Dots",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Dots",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Dots",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Dots",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "Dots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Dots",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "thumb_file",
                table: "Dots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "thumb_name",
                table: "Dots",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "time_close",
                table: "Dots",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "time_open",
                table: "Dots",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated",
                table: "Dots",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "Dots",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "register_code",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "register_service_id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "second_name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(nullable: true),
                    dot_id = table.Column<int>(nullable: false),
                    parent_id = table.Column<int>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Msgs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dot_id = table.Column<int>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Msgs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Msgs_Dots_dot_id",
                        column: x => x.dot_id,
                        principalTable: "Dots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Msgs_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dot_id = table.Column<int>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    markup = table.Column<int>(nullable: false),
                    status_id = table.Column<int>(nullable: false),
                    amount = table.Column<int>(nullable: false),
                    created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Payments_Dots_dot_id",
                        column: x => x.dot_id,
                        principalTable: "Dots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterServices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterServices", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "created", "description", "name", "updated", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 29, 12, 46, 59, 775, DateTimeKind.Local).AddTicks(2825), null, "Продукты", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2020, 11, 29, 12, 46, 59, 793, DateTimeKind.Local).AddTicks(6674), null, "Хэндмейд", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2020, 11, 29, 12, 46, 59, 793, DateTimeKind.Local).AddTicks(6933), null, "Вещи", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2020, 11, 29, 12, 46, 59, 793, DateTimeKind.Local).AddTicks(6982), null, "Услуги", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dots_category_id",
                table: "Dots",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Dots_user_id",
                table: "Dots",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_register_service_id",
                table: "AspNetUsers",
                column: "register_service_id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_user_id",
                table: "Categories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_user_id",
                table: "Comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Msgs_dot_id",
                table: "Msgs",
                column: "dot_id");

            migrationBuilder.CreateIndex(
                name: "IX_Msgs_user_id",
                table: "Msgs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_dot_id",
                table: "Payments",
                column: "dot_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_user_id",
                table: "Payments",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RegisterServices_register_service_id",
                table: "AspNetUsers",
                column: "register_service_id",
                principalTable: "RegisterServices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dots_Categories_category_id",
                table: "Dots",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dots_AspNetUsers_user_id",
                table: "Dots",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RegisterServices_register_service_id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dots_Categories_category_id",
                table: "Dots");

            migrationBuilder.DropForeignKey(
                name: "FK_Dots_AspNetUsers_user_id",
                table: "Dots");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Msgs");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RegisterServices");

            migrationBuilder.DropIndex(
                name: "IX_Dots_category_id",
                table: "Dots");

            migrationBuilder.DropIndex(
                name: "IX_Dots_user_id",
                table: "Dots");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_register_service_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "thumb_file",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "thumb_name",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "time_close",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "time_open",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "updated",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Dots");

            migrationBuilder.DropColumn(
                name: "created",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "register_code",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "register_service_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "second_name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "updated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "website",
                table: "Dots",
                newName: "Website");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Dots",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Dots",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Dots",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Dots",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Dots",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Dots",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Dots",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Dots",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbFile",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbName",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeClose",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeOpen",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Dots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
