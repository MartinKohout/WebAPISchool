using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class ManyToManyRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTags_Quotes_QuoteId",
                table: "QuoteTags");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTags_Tags_TagId",
                table: "QuoteTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteTags",
                table: "QuoteTags");

            migrationBuilder.DropIndex(
                name: "IX_QuoteTags_QuoteId",
                table: "QuoteTags");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "QuoteTags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteTags",
                table: "QuoteTags",
                columns: new[] { "QuoteId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTags_Quotes_QuoteId",
                table: "QuoteTags",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTags_Tags_TagId",
                table: "QuoteTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTags_Quotes_QuoteId",
                table: "QuoteTags");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTags_Tags_TagId",
                table: "QuoteTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteTags",
                table: "QuoteTags");

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "QuoteTags",
                keyColumns: new[] { "QuoteId", "TagId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "QuoteTags",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteTags",
                table: "QuoteTags",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_QuoteTags_QuoteId",
                table: "QuoteTags",
                column: "QuoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTags_Quotes_QuoteId",
                table: "QuoteTags",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTags_Tags_TagId",
                table: "QuoteTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
