using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rocnikovka_first.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Team_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Team_ID);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Training_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Start_time = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    End_time = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Training_ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Member_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_birth = table.Column<DateTime>(type: "DATE", nullable: false),
                    Birth_number = table.Column<int>(type: "int", nullable: false),
                    Health_insurance_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Health_insurance_number = table.Column<int>(type: "int", nullable: false),
                    Team_ID = table.Column<int>(type: "int", nullable: false),
                    Team_ID1 = table.Column<int>(type: "int", nullable: false),
                    Role_ID = table.Column<int>(type: "int", nullable: false),
                    Role_ID1 = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Member_ID);
                    table.ForeignKey(
                        name: "FK_Members_Roles_Role_ID1",
                        column: x => x.Role_ID1,
                        principalTable: "Roles",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_Teams_Team_ID1",
                        column: x => x.Team_ID1,
                        principalTable: "Teams",
                        principalColumn: "Team_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Representatives",
                columns: table => new
                {
                    Representative_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Member_ID1 = table.Column<int>(type: "int", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representatives", x => x.Representative_ID);
                    table.ForeignKey(
                        name: "FK_Representatives_Members_Member_ID1",
                        column: x => x.Member_ID1,
                        principalTable: "Members",
                        principalColumn: "Member_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Residences",
                columns: table => new
                {
                    Residence_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Member_ID1 = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postal_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City_part = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residences", x => x.Residence_ID);
                    table.ForeignKey(
                        name: "FK_Residences_Members_Member_ID1",
                        column: x => x.Member_ID1,
                        principalTable: "Members",
                        principalColumn: "Member_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Excuses",
                columns: table => new
                {
                    Excuse_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Excuser_ID = table.Column<int>(type: "int", nullable: false),
                    Member_ID1 = table.Column<int>(type: "int", nullable: false),
                    ExcuserRepresentative_ID = table.Column<int>(type: "int", nullable: false),
                    Excuse_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excuses", x => x.Excuse_ID);
                    table.ForeignKey(
                        name: "FK_Excuses_Members_Member_ID1",
                        column: x => x.Member_ID1,
                        principalTable: "Members",
                        principalColumn: "Member_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Excuses_Representatives_ExcuserRepresentative_ID",
                        column: x => x.ExcuserRepresentative_ID,
                        principalTable: "Representatives",
                        principalColumn: "Representative_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Excuses_ExcuserRepresentative_ID",
                table: "Excuses",
                column: "ExcuserRepresentative_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Excuses_Member_ID1",
                table: "Excuses",
                column: "Member_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Role_ID1",
                table: "Members",
                column: "Role_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Team_ID1",
                table: "Members",
                column: "Team_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_Member_ID1",
                table: "Representatives",
                column: "Member_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Residences_Member_ID1",
                table: "Residences",
                column: "Member_ID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Excuses");

            migrationBuilder.DropTable(
                name: "Residences");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Representatives");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
