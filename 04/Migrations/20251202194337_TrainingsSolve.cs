using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mach_rocnikova_prace.Migrations
{
    /// <inheritdoc />
    public partial class TrainingsSolve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_People_PersonId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_People_PersonId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_PersonId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Roles_PersonId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_PersonId",
                table: "Trainings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PersonId",
                table: "Roles",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_People_PersonId",
                table: "Roles",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_People_PersonId",
                table: "Trainings",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
