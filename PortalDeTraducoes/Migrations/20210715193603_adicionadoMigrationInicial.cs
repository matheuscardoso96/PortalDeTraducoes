using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalDeTraducoes.Migrations
{
    public partial class adicionadoMigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                    ReleaseDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CoverArtUrl = table.Column<string>(type: "varchar(500)", nullable: false)
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    PublishersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublisher", x => new { x.GamesID, x.PublishersID });
                    table.ForeignKey(
                        name: "FK_GamePublisher_Game_GamesID",
                        column: x => x.GamesID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePublisher_Publisher_PublishersID",
                        column: x => x.PublishersID,
                        principalTable: "Publisher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                name: "TranslationUser",
                columns: table => new
                {
                    TranslationsID = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationUser", x => new { x.TranslationsID, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TranslationUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslationUser_Translation_TranslationsID",
                        column: x => x.TranslationsID,
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupID",
                table: "AspNetUsers",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_GamePublisher_PublishersID",
                table: "GamePublisher",
                column: "PublishersID");

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
                name: "IX_TranslationUser_UsersId",
                table: "TranslationUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationVersion_DownloadLink",
                table: "TranslationVersion",
                column: "DownloadLink");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationVersion_TranslationID",
                table: "TranslationVersion",
                column: "TranslationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
