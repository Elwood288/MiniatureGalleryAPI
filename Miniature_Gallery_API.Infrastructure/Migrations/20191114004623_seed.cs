using Microsoft.EntityFrameworkCore.Migrations;

namespace Miniature_Gallery_API.Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Miniatures",
                columns: new[] { "Id", "Game", "Name" },
                values: new object[] { 1, "Heroscape", "Testy McGee" });

            migrationBuilder.InsertData(
                table: "Keywords",
                columns: new[] { "Id", "MiniatureId", "Name" },
                values: new object[] { 1, 1, "human" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Miniatures",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
