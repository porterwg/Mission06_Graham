using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission06_Graham.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FormID",
                table: "Movies",
                newName: "MovieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Movies",
                newName: "FormID");
        }
    }
}
