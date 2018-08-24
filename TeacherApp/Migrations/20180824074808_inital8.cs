using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherApp.Migrations
{
    public partial class inital8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Degrees_DegreeID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Degrees_DegreeID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Institutions_InstitutionID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Institutions_Teacher_InstitutionID",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DegreeID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_InstitutionID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_Teacher_InstitutionID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DegreeID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DegreeID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "InstitutionID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Teacher_InstitutionID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DegreeID",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Institution",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Persons",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Institution",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Persons",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "DegreeID",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstitutionID",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Teacher_InstitutionID",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DegreeID",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstitutionType = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionID);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
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
                    table.PrimaryKey("PK_Degrees", x => x.DegreeID);
                    table.ForeignKey(
                        name: "FK_Degrees_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DegreeID",
                table: "Persons",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_InstitutionID",
                table: "Persons",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Teacher_InstitutionID",
                table: "Persons",
                column: "Teacher_InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DegreeID",
                table: "Courses",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_InstitutionID",
                table: "Degrees",
                column: "InstitutionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Degrees_DegreeID",
                table: "Courses",
                column: "DegreeID",
                principalTable: "Degrees",
                principalColumn: "DegreeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Degrees_DegreeID",
                table: "Persons",
                column: "DegreeID",
                principalTable: "Degrees",
                principalColumn: "DegreeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Institutions_InstitutionID",
                table: "Persons",
                column: "InstitutionID",
                principalTable: "Institutions",
                principalColumn: "InstitutionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Institutions_Teacher_InstitutionID",
                table: "Persons",
                column: "Teacher_InstitutionID",
                principalTable: "Institutions",
                principalColumn: "InstitutionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
