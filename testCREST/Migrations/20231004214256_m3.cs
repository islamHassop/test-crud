using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testCREST.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_facluty_FaclutyId",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_facluty",
                table: "facluty");

            migrationBuilder.RenameTable(
                name: "facluty",
                newName: "faclutys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_faclutys",
                table: "faclutys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_faclutys_FaclutyId",
                table: "students",
                column: "FaclutyId",
                principalTable: "faclutys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_faclutys_FaclutyId",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_faclutys",
                table: "faclutys");

            migrationBuilder.RenameTable(
                name: "faclutys",
                newName: "facluty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_facluty",
                table: "facluty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_facluty_FaclutyId",
                table: "students",
                column: "FaclutyId",
                principalTable: "facluty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
