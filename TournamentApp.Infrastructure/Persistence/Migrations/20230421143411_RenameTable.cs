using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_CommunicationType_CommunicationTypeId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunicationType",
                table: "CommunicationType");

            migrationBuilder.RenameTable(
                name: "CommunicationType",
                newName: "CommunicationTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunicationTypes",
                table: "CommunicationTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_CommunicationTypes_CommunicationTypeId",
                table: "Tournaments",
                column: "CommunicationTypeId",
                principalTable: "CommunicationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_CommunicationTypes_CommunicationTypeId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunicationTypes",
                table: "CommunicationTypes");

            migrationBuilder.RenameTable(
                name: "CommunicationTypes",
                newName: "CommunicationType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunicationType",
                table: "CommunicationType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_CommunicationType_CommunicationTypeId",
                table: "Tournaments",
                column: "CommunicationTypeId",
                principalTable: "CommunicationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
