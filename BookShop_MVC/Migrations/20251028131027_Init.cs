using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShop_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100, nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "معاصر ، کلاسیک ", "رمان و داستان" },
                    { 2, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "غرب و شرق", "فلسفه و منطق" },
                    { 3, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "فناوری و تاریخ", "علمی و تاریخی" },
                    { 4, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "داستان های مصور", "کودک و نونجوان" },
                    { 5, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "طراحی و نقاشی", "هنر و معماری" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "CreatedAt", "ImgUrl", "NumberOfPages", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "آدولف هیتلر", 1, new DateTime(2024, 12, 12, 12, 12, 12, 12, DateTimeKind.Local), "/img/nabardman.jpg", 430, 750000m, "نبرد من" },
                    { 2, "افلاطون", 2, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "/img/jomhor.jpg", 410, 600000m, "جمهور" },
                    { 3, "چارلز داروین", 3, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "/img/khastgah.jpg", 510, 750000m, "خاستگاه گونه‌ها" },
                    { 4, "آنتوان دو سنت اگزوپری", 4, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "/img/shazde.jpg", 120, 280000m, "شازده کوچولو" },
                    { 5, "ارنست گامبریچ", 5, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "/img/tarikhhonar.jpg", 680, 850000m, "تاریخ هنر" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
