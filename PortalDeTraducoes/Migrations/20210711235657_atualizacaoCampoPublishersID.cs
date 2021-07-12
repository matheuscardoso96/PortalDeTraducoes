using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalDeTraducoes.Migrations
{
    public partial class atualizacaoCampoPublishersID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePublisher_Publisher_PublisherID",
                table: "GamePublisher");

            migrationBuilder.RenameColumn(
                name: "PublisherID",
                table: "GamePublisher",
                newName: "PublishersID");

            migrationBuilder.RenameIndex(
                name: "IX_GamePublisher_PublisherID",
                table: "GamePublisher",
                newName: "IX_GamePublisher_PublishersID");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePublisher_Publisher_PublishersID",
                table: "GamePublisher",
                column: "PublishersID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePublisher_Publisher_PublishersID",
                table: "GamePublisher");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "PublishersID",
                table: "GamePublisher",
                newName: "PublisherID");

            migrationBuilder.RenameIndex(
                name: "IX_GamePublisher_PublishersID",
                table: "GamePublisher",
                newName: "IX_GamePublisher_PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePublisher_Publisher_PublisherID",
                table: "GamePublisher",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
