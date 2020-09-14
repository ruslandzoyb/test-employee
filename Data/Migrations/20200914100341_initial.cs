using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Hired = table.Column<DateTime>(nullable: false),
                    Fired = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Ruslan", "Dzobko" },
                    { 2, "Alina", "Trykoz" },
                    { 3, "Max", "Maluk" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Dev" },
                    { 2, "QA" },
                    { 3, "BA" },
                    { 4, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "EmployeePositions",
                columns: new[] { "Id", "EmployeeId", "Fired", "Hired", "PositionId", "Salary" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2500.0 },
                    { 4, 3, null, new DateTime(2018, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1300.0 },
                    { 3, 2, new DateTime(2017, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 800.0 },
                    { 1, 2, null, new DateTime(2017, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_EmployeeId",
                table: "EmployeePositions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_PositionId",
                table: "EmployeePositions",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
