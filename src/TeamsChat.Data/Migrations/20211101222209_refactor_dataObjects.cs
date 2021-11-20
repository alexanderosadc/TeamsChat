using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamsChat.SSMS.Migrations
{
    public partial class refactor_dataObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachedFiles_Messages_MessageId",
                table: "AttachedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageGroupUser_MessageGroups_MessageGroupsId",
                table: "MessageGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageGroupUser_Users_UsersId",
                table: "MessageGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageGroups_MessageGroupId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageGroupsId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessagesId",
                table: "AttachedFiles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "MessageGroupId",
                table: "Messages",
                newName: "MessageGroupID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Messages",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_MessageGroupId",
                table: "Messages",
                newName: "IX_Messages_MessageGroupID");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "MessageGroupUser",
                newName: "UsersID");

            migrationBuilder.RenameColumn(
                name: "MessageGroupsId",
                table: "MessageGroupUser",
                newName: "MessageGroupsID");

            migrationBuilder.RenameIndex(
                name: "IX_MessageGroupUser_UsersId",
                table: "MessageGroupUser",
                newName: "IX_MessageGroupUser_UsersID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MessageGroups",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "AttachedFiles",
                newName: "MessageID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AttachedFiles",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_AttachedFiles_MessageId",
                table: "AttachedFiles",
                newName: "IX_AttachedFiles_MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachedFiles_Messages_MessageID",
                table: "AttachedFiles",
                column: "MessageID",
                principalTable: "Messages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageGroupUser_MessageGroups_MessageGroupsID",
                table: "MessageGroupUser",
                column: "MessageGroupsID",
                principalTable: "MessageGroups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageGroupUser_Users_UsersID",
                table: "MessageGroupUser",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageGroups_MessageGroupID",
                table: "Messages",
                column: "MessageGroupID",
                principalTable: "MessageGroups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachedFiles_Messages_MessageID",
                table: "AttachedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageGroupUser_MessageGroups_MessageGroupsID",
                table: "MessageGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageGroupUser_Users_UsersID",
                table: "MessageGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageGroups_MessageGroupID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MessageGroupID",
                table: "Messages",
                newName: "MessageGroupId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserID",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_MessageGroupID",
                table: "Messages",
                newName: "IX_Messages_MessageGroupId");

            migrationBuilder.RenameColumn(
                name: "UsersID",
                table: "MessageGroupUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "MessageGroupsID",
                table: "MessageGroupUser",
                newName: "MessageGroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageGroupUser_UsersID",
                table: "MessageGroupUser",
                newName: "IX_MessageGroupUser_UsersId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MessageGroups",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MessageID",
                table: "AttachedFiles",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "AttachedFiles",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AttachedFiles_MessageID",
                table: "AttachedFiles",
                newName: "IX_AttachedFiles_MessageId");

            migrationBuilder.AddColumn<int>(
                name: "MessageGroupsId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessagesId",
                table: "AttachedFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AttachedFiles_Messages_MessageId",
                table: "AttachedFiles",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageGroupUser_MessageGroups_MessageGroupsId",
                table: "MessageGroupUser",
                column: "MessageGroupsId",
                principalTable: "MessageGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageGroupUser_Users_UsersId",
                table: "MessageGroupUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
