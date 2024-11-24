using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Campus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNumber);
                });
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNumber", "FirstName", "LastName", "DateOfBirth", "Address", "Campus", "FieldOfStudy" },
                values: new object[,]
                {
                    {"student1", "Inga", "Ndyoki", DateOnly.FromDateTime(DateTime.Now), "Gauteng", "Jhb campus", "Engineering"},
                    {"student2", "John", "Black", DateOnly.FromDateTime(DateTime.Now), "Pretoria", "Pta campus", "Humanities"},
                    {"student3", "Jane", "Smith", DateOnly.FromDateTime(DateTime.Now), "Gauteng", "Jhb campus", "Engineering"}
                }
             );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
