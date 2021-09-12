using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamsChat.Data.Migrations
{
    public partial class rename_message_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageGroups_Messages_MessagesId",
                table: "MessageGroups");

            migrationBuilder.DropIndex(
                name: "IX_MessageGroups_MessagesId",
                table: "MessageGroups");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "MessageGroups");

            migrationBuilder.DropColumn(
                name: "MessagesId",
                table: "MessageGroups");

            migrationBuilder.AddColumn<int>(
                name: "MessageGroupsId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageGroupsId",
                table: "Messages",
                column: "MessageGroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageGroups_MessageGroupsId",
                table: "Messages",
                column: "MessageGroupsId",
                principalTable: "MessageGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageGroups_MessageGroupsId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageGroupsId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageGroupsId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "MessageGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessagesId",
                table: "MessageGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageGroups_MessagesId",
                table: "MessageGroups",
                column: "MessagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageGroups_Messages_MessagesId",
                table: "MessageGroups",
                column: "MessagesId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
