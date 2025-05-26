using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PO2projekt.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BookId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BookId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Authors",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "BookId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BookId",
                table: "Authors",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BookId",
                table: "Authors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
