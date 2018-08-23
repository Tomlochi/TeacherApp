using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherApp.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Degree_DegreeID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Person_TeacherID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Degree_Institution_InstitutionID",
                table: "Degree");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Institution_InstitutionID",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Person_TeacherID",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Institution",
                table: "Institution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degree",
                table: "Degree");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "Institution",
                newName: "Institutions");

            migrationBuilder.RenameTable(
                name: "Degree",
                newName: "Degrees");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Person_InstitutionID",
                table: "Persons",
                newName: "IX_Persons_InstitutionID");

            migrationBuilder.RenameIndex(
                name: "IX_Degree_InstitutionID",
                table: "Degrees",
                newName: "IX_Degrees_InstitutionID");

            migrationBuilder.RenameIndex(
                name: "IX_Course_TeacherID",
                table: "Courses",
                newName: "IX_Courses_TeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_Course_DegreeID",
                table: "Courses",
                newName: "IX_Courses_DegreeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Institutions",
                table: "Institutions",
                column: "InstitutionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees",
                column: "DegreeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Degrees_DegreeID",
                table: "Courses",
                column: "DegreeID",
                principalTable: "Degrees",
                principalColumn: "DegreeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Persons_TeacherID",
                table: "Courses",
                column: "TeacherID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_Institutions_InstitutionID",
                table: "Degrees",
                column: "InstitutionID",
                principalTable: "Institutions",
                principalColumn: "InstitutionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Institutions_InstitutionID",
                table: "Persons",
                column: "InstitutionID",
                principalTable: "Institutions",
                principalColumn: "InstitutionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Persons_TeacherID",
                table: "Review",
                column: "TeacherID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Degrees_DegreeID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Persons_TeacherID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Degrees_Institutions_InstitutionID",
                table: "Degrees");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Institutions_InstitutionID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Persons_TeacherID",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Institutions",
                table: "Institutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Institutions",
                newName: "Institution");

            migrationBuilder.RenameTable(
                name: "Degrees",
                newName: "Degree");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_InstitutionID",
                table: "Person",
                newName: "IX_Person_InstitutionID");

            migrationBuilder.RenameIndex(
                name: "IX_Degrees_InstitutionID",
                table: "Degree",
                newName: "IX_Degree_InstitutionID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherID",
                table: "Course",
                newName: "IX_Course_TeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_DegreeID",
                table: "Course",
                newName: "IX_Course_DegreeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Institution",
                table: "Institution",
                column: "InstitutionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degree",
                table: "Degree",
                column: "DegreeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Degree_DegreeID",
                table: "Course",
                column: "DegreeID",
                principalTable: "Degree",
                principalColumn: "DegreeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Person_TeacherID",
                table: "Course",
                column: "TeacherID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Degree_Institution_InstitutionID",
                table: "Degree",
                column: "InstitutionID",
                principalTable: "Institution",
                principalColumn: "InstitutionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Institution_InstitutionID",
                table: "Person",
                column: "InstitutionID",
                principalTable: "Institution",
                principalColumn: "InstitutionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Person_TeacherID",
                table: "Review",
                column: "TeacherID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
