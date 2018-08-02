using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherApp.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Enrolled",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Graduated",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstitutionID",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonPrice",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    InstitutionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    InstitutionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.InstitutionID);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Published = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    TeacherID = table.Column<int>(nullable: false),
                    ReviewContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_Person_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    DegreeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DegreeName = table.Column<string>(nullable: true),
                    DurationinYears = table.Column<int>(nullable: false),
                    InstitutionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.DegreeID);
                    table.ForeignKey(
                        name: "FK_Degree_Institution_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institution",
                        principalColumn: "InstitutionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: true),
                    Credits = table.Column<int>(nullable: false),
                    DegreeID = table.Column<int>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_Degree_DegreeID",
                        column: x => x.DegreeID,
                        principalTable: "Degree",
                        principalColumn: "DegreeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Person_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_InstitutionID",
                table: "Person",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DegreeID",
                table: "Course",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherID",
                table: "Course",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Degree_InstitutionID",
                table: "Degree",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_TeacherID",
                table: "Review",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Institution_InstitutionID",
                table: "Person",
                column: "InstitutionID",
                principalTable: "Institution",
                principalColumn: "InstitutionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Institution_InstitutionID",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropIndex(
                name: "IX_Person_InstitutionID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Enrolled",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Graduated",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "InstitutionID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LessonPrice",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Person");
        }
    }
}
