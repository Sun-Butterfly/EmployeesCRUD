using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeesCRUD.Migrations
{
    /// <inheritdoc />
    public partial class updatesJobTitles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobTitle",
                columns: new[] { "Title", "Salary" },
                values: new object[,]
                {
                    { "Junior", 8000 },
                    { "Middle", 10000 },
                    { "Senior", 12000 },
                    { "TeamLead", 15000 },
                    { "TechLead", 14000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "Title",
                keyValue: "Junior");

            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "Title",
                keyValue: "Middle");

            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "Title",
                keyValue: "Senior");

            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "Title",
                keyValue: "TeamLead");

            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "Title",
                keyValue: "TechLead");
        }
    }
}
