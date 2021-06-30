using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalDeTraducoes.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperGame",
                columns: table => new
                {
                    DevelopersID = table.Column<int>(type: "int", nullable: false),
                    GamesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperGame", x => new { x.DevelopersID, x.GamesID });
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Developer_DevelopersID",
                        column: x => x.DevelopersID,
                        principalTable: "Developer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Game_GamesID",
                        column: x => x.GamesID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GamesID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GamesID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_GameGenre_Game_GamesID",
                        column: x => x.GamesID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "varchar(90)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Translation_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Translation_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "varchar(90)", nullable: false),
                    Country = table.Column<string>(type: "varchar(90)", nullable: true),
                    State = table.Column<string>(type: "varchar(90)", nullable: true),
                    City = table.Column<string>(type: "varchar(90)", nullable: true),
                    Password = table.Column<string>(type: "varchar(30)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    GamesID = table.Column<int>(type: "int", nullable: false),
                    PlatformsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => new { x.GamesID, x.PlatformsID });
                    table.ForeignKey(
                        name: "FK_GamePlatform_Game_GamesID",
                        column: x => x.GamesID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Platform_PlatformsID",
                        column: x => x.PlatformsID,
                        principalTable: "Platform",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePublisher",
                columns: table => new
                {
                    GamesID = table.Column<int>(type: "int", nullable: false),
                    PublisherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublisher", x => new { x.GamesID, x.PublisherID });
                    table.ForeignKey(
                        name: "FK_GamePublisher_Game_GamesID",
                        column: x => x.GamesID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePublisher_Publisher_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publisher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationImage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TranslationImage_Translation_TranslationID",
                        column: x => x.TranslationID,
                        principalTable: "Translation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationVersion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "varchar(20)", nullable: false),
                    DownloadLink = table.Column<string>(type: "varchar(255)", nullable: false),
                    PatchNote = table.Column<string>(type: "varchar(255)", nullable: false),
                    TranslationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationVersion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TranslationVersion_Translation_TranslationID",
                        column: x => x.TranslationID,
                        principalTable: "Translation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TranslationUser",
                columns: table => new
                {
                    TranslationsID = table.Column<int>(type: "int", nullable: false),
                    UsersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationUser", x => new { x.TranslationsID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_TranslationUser_Translation_TranslationsID",
                        column: x => x.TranslationsID,
                        principalTable: "Translation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslationUser_User_UsersID",
                        column: x => x.UsersID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "ID", "ImageUrl", "Name" },
                values: new object[] { 1, "", "Capcom" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 19, "Retro" },
                    { 20, "Educativo" },
                    { 21, "Jogo de Tabuleiro" },
                    { 22, "Co-op" },
                    { 23, "Mundo Aberto" },
                    { 24, "Plataformas" },
                    { 18, "Terror" },
                    { 25, "Realidade Virtual" },
                    { 28, "Tiro" },
                    { 29, "Romance Visual" },
                    { 30, "Point & Click" },
                    { 31, "Plataforma" },
                    { 32, "RPG de Ação" },
                    { 33, "JRPG" },
                    { 27, "Ação/Aventura" },
                    { 17, "Arcade" },
                    { 26, "Sobrevivência" },
                    { 15, "Terceira Pessoa" },
                    { 16, "Ficção Científica" },
                    { 1, "Ação" },
                    { 2, "Aventura" },
                    { 3, "Casual" },
                    { 4, "Simulador" },
                    { 6, "RPG" },
                    { 7, "Multijogador" },
                    { 5, "Estratégia" },
                    { 8, "3D" },
                    { 9, "Esporte" },
                    { 10, "Quebra-Cabeças" },
                    { 11, "Fantasia" },
                    { 12, "Corrida" },
                    { 13, "Anime" },
                    { 14, "Primeira Pessoa" }
                });

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "ID", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 28, "", "Nintendo DS" },
                    { 23, "", "Game Boy Advance" },
                    { 24, "", "Playstation 2" },
                    { 25, "", "Game Cube " },
                    { 26, "", "Xbox" },
                    { 27, "", "PSP" },
                    { 22, "", "Dreamcast" },
                    { 29, "", "Xbox 360" }
                });

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "ID", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 37, "", "Nintendo Switch" },
                    { 31, "", "Playstation 3" },
                    { 32, "", "Dingoo" },
                    { 33, "", "PSVITA" },
                    { 34, "", "3DS" },
                    { 35, "", "Wii U" },
                    { 36, "", "Playstation 4" },
                    { 38, "", "Java - Celular" },
                    { 21, "", "WonderSwan Color" },
                    { 30, "", "Wii" },
                    { 20, "", "WonderSwan" },
                    { 3, "", "SG-1000" },
                    { 18, "", "Game Boy Color" },
                    { 1, "", "Atari" },
                    { 2, "", "Colecovision" },
                    { 39, "", "Android" },
                    { 4, "", "NES" },
                    { 5, "", "Famicom Disk System" },
                    { 6, "", "PC Engine" },
                    { 7, "", "Master System" },
                    { 8, "", "SNES" },
                    { 9, "", "Mega Drive" },
                    { 10, "", "Sega 32X" },
                    { 11, "", "Sega CD" },
                    { 12, "", "Game Gear" },
                    { 13, "", "Game Boy" },
                    { 14, "", "Nintendo 64" },
                    { 15, "", "Playstation" },
                    { 16, "", "Sega Saturn" },
                    { 17, "", "Atari Jaguar" },
                    { 19, "", "3DO" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "ID", "ImageUrl", "Name" },
                values: new object[] { 1, "", "Capcom" });

            migrationBuilder.CreateIndex(
                name: "IX_Developer_Name",
                table: "Developer",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperGame_GamesID",
                table: "DeveloperGame",
                column: "GamesID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_Title",
                table: "Game",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenreID",
                table: "GameGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_PlatformsID",
                table: "GamePlatform",
                column: "PlatformsID");

            migrationBuilder.CreateIndex(
                name: "IX_GamePublisher_PublisherID",
                table: "GamePublisher",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Name",
                table: "Genre",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Name",
                table: "Group",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Platform_Name",
                table: "Platform",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Platform_Name",
                table: "Publisher",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_GameID",
                table: "Translation",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_GroupID",
                table: "Translation",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_Language",
                table: "Translation",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationImage_TranslationID",
                table: "TranslationImage",
                column: "TranslationID");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationUser_UsersID",
                table: "TranslationUser",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationVersion_DownloadLink",
                table: "TranslationVersion",
                column: "DownloadLink");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationVersion_TranslationID",
                table: "TranslationVersion",
                column: "TranslationID");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupID",
                table: "User",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_User_NickName",
                table: "User",
                column: "NickName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperGame");

            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropTable(
                name: "GamePublisher");

            migrationBuilder.DropTable(
                name: "TranslationImage");

            migrationBuilder.DropTable(
                name: "TranslationUser");

            migrationBuilder.DropTable(
                name: "TranslationVersion");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
