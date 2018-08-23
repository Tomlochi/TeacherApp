using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherApp.Migrations
{
    public partial class intial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveSince",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Enrolled",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "DegreeID",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Teacher_InstitutionID",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DegreeID",
                table: "Persons",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Teacher_InstitutionID",
                table: "Persons",
                column: "Teacher_InstitutionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Degrees_DegreeID",
                table: "Persons",
                column: "DegreeID",
                principalTable: "Degrees",
                principalColumn: "DegreeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Institutions_Teacher_InstitutionID",
                table: "Persons",
                column: "Teacher_InstitutionID",
                principalTable: "Institutions",
                principalColumn: "InstitutionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Degrees_DegreeID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Institutions_Teacher_InstitutionID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DegreeID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_Teacher_InstitutionID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DegreeID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Teacher_InstitutionID",
                table: "Persons");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveSince",
                table: "Persons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Enrolled",
                table: "Persons",
                nullable: true);
        }
    }
}
