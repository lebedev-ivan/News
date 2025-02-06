using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Migrations
{
    /// <inheritdoc />
    public partial class ArticlesInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("30fb2dd3-ea0e-4f05-b0db-ef6341a593f0"),
                column: "Title",
                value: "В космос запущен новый спутник");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("30fb2dd3-ea0e-4f05-b0db-ef6341a593f0"),
                column: "Title",
                value: "В космос запущен новый спутнки");
        }
    }
}
