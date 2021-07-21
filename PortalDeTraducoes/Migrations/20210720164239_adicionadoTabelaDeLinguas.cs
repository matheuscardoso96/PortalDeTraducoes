using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalDeTraducoes.Migrations
{
    public partial class adicionadoTabelaDeLinguas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Translation_Language",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Translation");

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "Translation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    EmojiFlag = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "EmojiFlag", "Name" },
                values: new object[,]
                {
                    { 1, "🇧🇷", "Português Brasileiro" },
                    { 2, "🇵🇹", "Português de Portugal" },
                    { 3, "🇪🇦", "Espanhol" },
                    { 4, "🇺🇸", "Inglês EUA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_LanguageID",
                table: "Translation",
                column: "LanguageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Languages_LanguageID",
                table: "Translation",
                column: "LanguageID",
                principalTable: "Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Languages_LanguageID",
                table: "Translation");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Translation_LanguageID",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "Translation");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Translation",
                type: "varchar(90)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_Language",
                table: "Translation",
                column: "Language");
        }
    }
}
