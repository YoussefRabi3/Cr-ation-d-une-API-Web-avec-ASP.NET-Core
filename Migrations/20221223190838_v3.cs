using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "departementid",
                table: "salaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_dep",
                table: "salaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_salaries_departementid",
                table: "salaries",
                column: "departementid");

            migrationBuilder.AddForeignKey(
                name: "FK_salaries_departements_departementid",
                table: "salaries",
                column: "departementid",
                principalTable: "departements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salaries_departements_departementid",
                table: "salaries");

            migrationBuilder.DropIndex(
                name: "IX_salaries_departementid",
                table: "salaries");

            migrationBuilder.DropColumn(
                name: "departementid",
                table: "salaries");

            migrationBuilder.DropColumn(
                name: "id_dep",
                table: "salaries");
        }
    }
}
