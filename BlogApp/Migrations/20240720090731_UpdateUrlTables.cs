using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUrlTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Tags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Posts",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Posts");
        }
    }
}
