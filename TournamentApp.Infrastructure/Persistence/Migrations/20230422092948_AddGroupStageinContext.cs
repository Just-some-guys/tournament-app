using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupStageinContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_GroupStage_GroupStageId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStage_Tournaments_TournamentId",
                table: "GroupStage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStage",
                table: "GroupStage");

            migrationBuilder.RenameTable(
                name: "GroupStage",
                newName: "GroupStages");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStage_TournamentId",
                table: "GroupStages",
                newName: "IX_GroupStages_TournamentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStages",
                table: "GroupStages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_GroupStages_GroupStageId",
                table: "Group",
                column: "GroupStageId",
                principalTable: "GroupStages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStages_Tournaments_TournamentId",
                table: "GroupStages",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_GroupStages_GroupStageId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStages_Tournaments_TournamentId",
                table: "GroupStages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStages",
                table: "GroupStages");

            migrationBuilder.RenameTable(
                name: "GroupStages",
                newName: "GroupStage");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStages_TournamentId",
                table: "GroupStage",
                newName: "IX_GroupStage_TournamentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStage",
                table: "GroupStage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_GroupStage_GroupStageId",
                table: "Group",
                column: "GroupStageId",
                principalTable: "GroupStage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStage_Tournaments_TournamentId",
                table: "GroupStage",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
