using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeVoices.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Seiyuu_Chars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Characters",
                table: "Seiyuu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Characters",
                table: "Seiyuu",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
