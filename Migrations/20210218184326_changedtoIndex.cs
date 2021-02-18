using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentiWeb.Migrations
{
    public partial class changedtoIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Student_NrMatricol",
                table: "Student");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Nota_StudentID_DisciplinaID",
                table: "Nota");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Disciplina_Nume",
                table: "Disciplina");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Disciplina",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Student_NrMatricol",
                table: "Student",
                column: "NrMatricol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nota_StudentID_DisciplinaID",
                table: "Nota",
                columns: new[] { "StudentID", "DisciplinaID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_Nume",
                table: "Disciplina",
                column: "Nume",
                unique: true,
                filter: "[Nume] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Student_NrMatricol",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Nota_StudentID_DisciplinaID",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_Nume",
                table: "Disciplina");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Disciplina",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Student_NrMatricol",
                table: "Student",
                column: "NrMatricol");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Nota_StudentID_DisciplinaID",
                table: "Nota",
                columns: new[] { "StudentID", "DisciplinaID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Disciplina_Nume",
                table: "Disciplina",
                column: "Nume");
        }
    }
}
