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
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
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
                    IsCompany = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
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
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
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
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
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
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
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
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
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
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
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
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
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
                columns: new[] { "Id", "CreatedBy", "CreationDate", "ModificationDate", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Local), 0, "JobSeeker" },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Local), 0, "Employer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Email", "IsCompany", "ModificationDate", "ModifiedBy", "Password" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4775), "info@acme.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" },
                    { 2, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4786), "contact@globex.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" },
                    { 3, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4788), "contact@microsoft.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" },
                    { 4, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4789), "contact@uber.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" },
                    { 5, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4790), "support@initech.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" },
                    { 6, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4791), "john.doe@example.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" },
                    { 7, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4793), "jane.smith@example.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" },
                    { 8, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4794), "bob.johnson@example.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" },
                    { 9, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4795), "alice.williams@example.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" },
                    { 10, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4796), "random@example.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "password" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "CreatedBy", "CreationDate", "Email", "ModificationDate", "ModifiedBy", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, CA 12345", 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4970), "info@acme.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Acme Corporation", "1-800-555-1212", 1 },
                    { 2, "456 Elm St, Business City, NY 54321", 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4971), "contact@globex.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Globex Corporation", "1-888-555-2323", 2 },
                    { 3, "456 Elm St, Business City, NY 54321", 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4973), "contact@microsoft.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Microsoft", "1-888-555-2323", 3 },
                    { 4, "456 Elm St, Business City, NY 54321", 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4975), "contact@uber.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Uber", "1-888-555-2323", 4 },
                    { 5, "789 Tech St, Silicon Valley, CA 98765", 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(4976), "support@initech.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Initech", "1-877-555-3434", 5 }
                });

            migrationBuilder.InsertData(
                table: "JobSeekers",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Email", "IsFresh", "ModificationDate", "ModifiedBy", "Name", "UserId", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(5001), "john.doe@example.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "John Doe", 6, 5 },
                    { 2, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(5003), "jane.smith@example.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Jane Smith", 7, 0 },
                    { 3, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(5004), "bob.johnson@example.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Bob Johnson", 8, 7 },
                    { 4, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(5005), "alice.williams@example.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Alice Williams", 9, 0 },
                    { 5, 0, new DateTime(2023, 12, 28, 11, 8, 3, 806, DateTimeKind.Local).AddTicks(5007), "random@example.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Random", 10, 0 }
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
                name: "IX_File_JobSeekerId",
                table: "File",
                column: "JobSeekerId",
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
                name: "File");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "JobSeekers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
