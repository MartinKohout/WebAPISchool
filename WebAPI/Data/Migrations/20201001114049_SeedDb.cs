using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Blablabla very smart quote :)" },
                    { 2, "Blablabla very another smart quote :)" },
                    { 3, "Kdo pozdě chodí, sám sobě škodí." }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Kohout" },
                    { 2, 0, "Pepa Autor" },
                    { 3, 1, "České příslový" }
                });

            migrationBuilder.InsertData(
                table: "QuoteTags",
                columns: new[] { "Id", "QuoteId", "TagId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "QuoteTags",
                columns: new[] { "Id", "QuoteId", "TagId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "QuoteTags",
                columns: new[] { "Id", "QuoteId", "TagId" },
                values: new object[] { 3, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
