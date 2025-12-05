using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kemar.MBS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RenameTheatreNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Theatres",
                newName: "TheatreName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TheatreName",
                table: "Theatres",
                newName: "Name");
        }
    }
}
