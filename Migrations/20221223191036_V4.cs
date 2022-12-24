using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salaries_departements_departementid",
                table: "salaries");

            migrationBuilder.DropColumn(
                name: "id_dep",
                table: "salaries");

            migrationBuilder.RenameColumn(
                name: "departementid",
                table: "salaries",
                newName: "departementId");

            migrationBuilder.RenameIndex(
                name: "IX_salaries_departementid",
                table: "salaries",
                newName: "IX_salaries_departementId");

            migrationBuilder.AddForeignKey(
                name: "FK_salaries_departements_departementId",
                table: "salaries",
                column: "departementId",
                principalTable: "departements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salaries_departements_departementId",
                table: "salaries");

            migrationBuilder.RenameColumn(
                name: "departementId",
                table: "salaries",
                newName: "departementid");

            migrationBuilder.RenameIndex(
                name: "IX_salaries_departementId",
                table: "salaries",
                newName: "IX_salaries_departementid");

            migrationBuilder.AddColumn<int>(
                name: "id_dep",
                table: "salaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_salaries_departements_departementid",
                table: "salaries",
                column: "departementid",
                principalTable: "departements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
