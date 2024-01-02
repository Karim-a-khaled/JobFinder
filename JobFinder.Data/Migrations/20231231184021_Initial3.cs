using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_JobSeekerCvId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_JobSeekerProfilePhotoId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyProfilePhotoId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "JobSeekerProfilePhotoId",
                table: "JobSeekers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobSeekerCvId",
                table: "JobSeekers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyProfilePhotoId",
                table: "Companies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_JobSeekerCvId",
                table: "JobSeekers",
                column: "JobSeekerCvId",
                unique: true,
                filter: "[JobSeekerCvId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_JobSeekerProfilePhotoId",
                table: "JobSeekers",
                column: "JobSeekerProfilePhotoId",
                unique: true,
                filter: "[JobSeekerProfilePhotoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyProfilePhotoId",
                table: "Companies",
                column: "CompanyProfilePhotoId",
                unique: true,
                filter: "[CompanyProfilePhotoId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_JobSeekerCvId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_JobSeekerProfilePhotoId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyProfilePhotoId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "JobSeekerProfilePhotoId",
                table: "JobSeekers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobSeekerCvId",
                table: "JobSeekers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyProfilePhotoId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_JobSeekerCvId",
                table: "JobSeekers",
                column: "JobSeekerCvId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_JobSeekerProfilePhotoId",
                table: "JobSeekers",
                column: "JobSeekerProfilePhotoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyProfilePhotoId",
                table: "Companies",
                column: "CompanyProfilePhotoId",
                unique: true);
        }
    }
}
