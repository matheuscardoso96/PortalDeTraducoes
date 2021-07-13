using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalDeTraducoes.Migrations
{
    public partial class adicionadoUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleID",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "ID", "Description" },
                values: new object[] { 1, "Administrador" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "ID", "Description" },
                values: new object[] { 2, "Moderador" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "ID", "Description" },
                values: new object[] { 3, "Usuario" });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleID",
                table: "User",
                column: "UserRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Description",
                table: "UserRole",
                column: "Description");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRole_UserRoleID",
                table: "User",
                column: "UserRoleID",
                principalTable: "UserRole",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRole_UserRoleID",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_User_UserRoleID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserRoleID",
                table: "User");
        }
    }
}
