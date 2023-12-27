using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timer = table.Column<int>(type: "int", nullable: true),
                    RoleType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    isCompany = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSeekers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    IsFresh = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSeekers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationDate", "ModificationDate", "Name", "RoleType", "Timer" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), "JobSeeker", 0, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), "Employer", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "ModificationDate", "Password", "IsCompany" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6225), "info@acme.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", true },
                    { 2, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6236), "contact@globex.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", true },
                    { 3, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6237), "contact@microsoft.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", true },
                    { 4, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6239), "contact@uber.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", true },
                    { 5, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6240), "support@initech.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", true },
                    { 6, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6241), "john.doe@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", false },
                    { 7, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6242), "jane.smith@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", false },
                    { 8, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6293), "bob.johnson@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", false },
                    { 9, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6294), "alice.williams@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", false },
                    { 10, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6295), "random@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", false }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "CreationDate", "Email", "ModificationDate", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, CA 12345", new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6466), "info@acme.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acme Corporation", "1-800-555-1212", 1 },
                    { 2, "456 Elm St, Business City, NY 54321", new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6468), "contact@globex.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Globex Corporation", "1-888-555-2323", 2 },
                    { 3, "456 Elm St, Business City, NY 54321", new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6470), "contact@microsoft.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Microsoft", "1-888-555-2323", 3 },
                    { 4, "456 Elm St, Business City, NY 54321", new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6471), "contact@uber.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uber", "1-888-555-2323", 4 },
                    { 5, "789 Tech St, Silicon Valley, CA 98765", new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6473), "support@initech.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Initech", "1-877-555-3434", 5 }
                });

            migrationBuilder.InsertData(
                table: "JobSeekers",
                columns: new[] { "Id", "CreationDate", "Email", "IsFresh", "ModificationDate", "Name", "UserId", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6495), "john.doe@example.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", 6, 5 },
                    { 2, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6497), "jane.smith@example.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", 7, 0 },
                    { 3, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6498), "bob.johnson@example.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Johnson", 8, 7 },
                    { 4, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6499), "alice.williams@example.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Williams", 9, 0 },
                    { 5, new DateTime(2023, 12, 27, 10, 17, 2, 274, DateTimeKind.Local).AddTicks(6501), "random@example.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Random", 10, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobId",
                table: "Applications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobSeekerId",
                table: "Applications",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_UserId",
                table: "JobSeekers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "JobSeekers");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
