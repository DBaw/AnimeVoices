using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeVoices.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Props : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Aliases",
                table: "Anime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimeId",
                table: "Character",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Aliases",
                table: "Anime",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
