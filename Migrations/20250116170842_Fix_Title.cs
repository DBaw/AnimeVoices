using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeVoices.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Title : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EngTitle",
                table: "Anime",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngTitle",
                table: "Anime");
        }
    }
}
