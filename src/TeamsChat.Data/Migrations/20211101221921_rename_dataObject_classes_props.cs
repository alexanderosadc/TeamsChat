using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamsChat.SSMS.Migrations
{
    public partial class rename_dataObject_classes_props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachedFiles_Messages_MessagesId",
                table: "AttachedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageGroups_MessageGroupsId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UsersId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageGroupsId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UsersId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_AttachedFiles_MessagesId",
                table: "AttachedFiles");

            migrationBuilder.AddColumn<int>(
                name: "MessageGroupId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "AttachedFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageGroupId",
                table: "Messages",
                column: "MessageGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachedFiles_MessageId",
                table: "AttachedFiles",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachedFiles_Messages_MessageId",
                table: "AttachedFiles",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageGroups_MessageGroupId",
                table: "Messages",
                column: "MessageGroupId",
                principalTable: "MessageGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachedFiles_Messages_MessageId",
                table: "AttachedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageGroups_MessageGroupId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageGroupId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_AttachedFiles_MessageId",
                table: "AttachedFiles");

            migrationBuilder.DropColumn(
                name: "MessageGroupId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "AttachedFiles");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageGroupsId",
                table: "Messages",
                column: "MessageGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UsersId",
                table: "Messages",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachedFiles_MessagesId",
                table: "AttachedFiles",
                column: "MessagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachedFiles_Messages_MessagesId",
                table: "AttachedFiles",
                column: "MessagesId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageGroups_MessageGroupsId",
                table: "Messages",
                column: "MessageGroupsId",
                principalTable: "MessageGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UsersId",
                table: "Messages",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
