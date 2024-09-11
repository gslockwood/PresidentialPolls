using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresidentialPolls.Migrations
{
    /// <inheritdoc />
    public partial class addedstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Polls",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Polls");
        }
    }
}
