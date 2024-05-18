using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookRent.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Author", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, " কাজী নজরুল ইসলাম", "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!", 142.0, "অগ্নিবীণা" },
                    { 2, " কাজী নজরুল ইসলাম", "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!", 142.0, "মৃত্যুক্ষুধা" },
                    { 3, "আহমদ মতিউর রহমান", "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!", 200.0, "বিশ্বকবি রবীন্দ্রনাথ ঠাকুর (জীবনীগ্রন্থ)" },
                    { 4, "আহমদ মতিউর রহমান", "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!", 142.0, "গণতন্ত্রের মানসপুত্র হোসেন শহীদ সোহরাওয়ার্দী" },
                    { 5, "আহমদ মতিউর রহমান", "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!", 300.0, "নবাব সিরাজউদ্দৌলার পতনের কারণ ও বাংলার ২০০ বছর" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");
        }
    }
}
