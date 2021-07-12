using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalDeTraducoes.Migrations
{
    public partial class adicionadoCampoDeUrlDaCapa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverArtUrl",
                table: "Game",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverArtUrl",
                table: "Game");
        }
    }
}
