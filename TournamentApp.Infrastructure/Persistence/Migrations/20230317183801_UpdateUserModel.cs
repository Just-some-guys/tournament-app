using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationMember_Organization_OrganizationId",
                table: "OrganizationMember");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationMember_Users_UserId",
                table: "OrganizationMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Organization_CreatorId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationMember",
                table: "OrganizationMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "OrganizationMember");

            migrationBuilder.RenameTable(
                name: "OrganizationMember",
                newName: "OrganizationMembers");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationMember_UserId",
                table: "OrganizationMembers",
                newName: "IX_OrganizationMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationMember_OrganizationId",
                table: "OrganizationMembers",
                newName: "IX_OrganizationMembers_OrganizationId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationRole",
                table: "OrganizationMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationMembers",
                table: "OrganizationMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationMembers_Organizations_OrganizationId",
                table: "OrganizationMembers",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationMembers_Users_UserId",
                table: "OrganizationMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Organizations_CreatorId",
                table: "Tournaments",
                column: "CreatorId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationMembers_Organizations_OrganizationId",
                table: "OrganizationMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationMembers_Users_UserId",
                table: "OrganizationMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Organizations_CreatorId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationMembers",
                table: "OrganizationMembers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrganizationRole",
                table: "OrganizationMembers");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameTable(
                name: "OrganizationMembers",
                newName: "OrganizationMember");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationMembers_UserId",
                table: "OrganizationMember",
                newName: "IX_OrganizationMember_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationMembers_OrganizationId",
                table: "OrganizationMember",
                newName: "IX_OrganizationMember_OrganizationId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "OrganizationMember",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationMember",
                table: "OrganizationMember",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationMember_Organization_OrganizationId",
                table: "OrganizationMember",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationMember_Users_UserId",
                table: "OrganizationMember",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Organization_CreatorId",
                table: "Tournaments",
                column: "CreatorId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
