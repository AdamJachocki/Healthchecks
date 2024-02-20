using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherArchives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherArchives", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherArchives_City",
                table: "WeatherArchives",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherArchives_Date",
                table: "WeatherArchives",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherArchives_Id",
                table: "WeatherArchives",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherArchives");
        }
    }
}
