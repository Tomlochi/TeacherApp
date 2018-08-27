using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherApp.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Courses_CourseID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CourseID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.TeacherID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Persons_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseID",
                table: "TeacherCourses",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CourseID",
                table: "Persons",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Courses_CourseID",
                table: "Persons",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
