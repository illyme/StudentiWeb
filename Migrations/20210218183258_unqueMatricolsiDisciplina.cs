using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentiWeb.Migrations
{
    public partial class unqueMatricolsiDisciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Disciplina",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Student_NrMatricol",
                table: "Student",
                column: "NrMatricol");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Disciplina_Nume",
                table: "Disciplina",
                column: "Nume");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Student_NrMatricol",
                table: "Student");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Disciplina_Nume",
                table: "Disciplina");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Disciplina",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
