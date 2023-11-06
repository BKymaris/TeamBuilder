using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreWebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreferredTeam",
                table: "Players",
                newName: "PreferredTeamSide");

            migrationBuilder.AlterColumn<decimal>(
                name: "Skill",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreferredTeamSide",
                table: "Players",
                newName: "PreferredTeam");

            migrationBuilder.AlterColumn<int>(
                name: "Skill",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
