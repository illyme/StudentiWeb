using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentiWeb.Migrations
{
    public partial class uniqueNota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Nota_StudentID",
                table: "Nota");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Nota_StudentID_DisciplinaID",
                table: "Nota",
                columns: new[] { "StudentID", "DisciplinaID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Nota_StudentID_DisciplinaID",
                table: "Nota");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_StudentID",
                table: "Nota",
                column: "StudentID");
        }
    }
}
