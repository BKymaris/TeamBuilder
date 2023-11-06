using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreWebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreferredTeamSide",
                table: "Players",
                newName: "PreferredTeam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreferredTeam",
                table: "Players",
                newName: "PreferredTeamSide");
        }
    }
}
