using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreWebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class HockeyPlayerSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "Players",
                newName: "Vision");

            migrationBuilder.AddColumn<decimal>(
                name: "Dribbling",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GuardianShip",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Interception",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Opening",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Pass",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PuckSelection",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivingPuck",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Shot",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Speed",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Staking",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Stamina",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dribbling",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GuardianShip",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Interception",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Opening",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Pass",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PuckSelection",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ReceivingPuck",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Shot",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Staking",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Stamina",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Vision",
                table: "Players",
                newName: "Skill");
        }
    }
}
