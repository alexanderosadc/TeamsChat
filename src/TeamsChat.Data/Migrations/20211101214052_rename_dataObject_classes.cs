using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamsChat.Data.Migrations
{
    public partial class rename_dataObject_classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageGroupsUsers");

            migrationBuilder.CreateTable(
                name: "MessageGroupUser",
                columns: table => new
                {
                    MessageGroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageGroupUser", x => new { x.MessageGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MessageGroupUser_MessageGroups_MessageGroupsId",
                        column: x => x.MessageGroupsId,
                        principalTable: "MessageGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageGroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageGroupUser_UsersId",
                table: "MessageGroupUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageGroupUser");

            migrationBuilder.CreateTable(
                name: "MessageGroupsUsers",
                columns: table => new
                {
                    MessageGroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageGroupsUsers", x => new { x.MessageGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MessageGroupsUsers_MessageGroups_MessageGroupsId",
                        column: x => x.MessageGroupsId,
                        principalTable: "MessageGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageGroupsUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageGroupsUsers_UsersId",
                table: "MessageGroupsUsers",
                column: "UsersId");
        }
    }
}
