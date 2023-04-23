using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTournamentTeamsToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_TournamentTeam_WinnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TournamentTeam_WinnerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeam_Group_GroupId",
                table: "TournamentTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeam_Matches_MatchId",
                table: "TournamentTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeam_Teams_TeamId",
                table: "TournamentTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeam_Tournaments_TournamentId",
                table: "TournamentTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentTeam",
                table: "TournamentTeam");

            migrationBuilder.RenameTable(
                name: "TournamentTeam",
                newName: "TournamentTeams");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeam_TournamentId",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeam_TeamId",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeam_MatchId",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeam_GroupId",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentTeams",
                table: "TournamentTeams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TournamentTeams_WinnerId",
                table: "Games",
                column: "WinnerId",
                principalTable: "TournamentTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TournamentTeams_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "TournamentTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_Group_GroupId",
                table: "TournamentTeams",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_Matches_MatchId",
                table: "TournamentTeams",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_Teams_TeamId",
                table: "TournamentTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_Tournaments_TournamentId",
                table: "TournamentTeams",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_TournamentTeams_WinnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TournamentTeams_WinnerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_Group_GroupId",
                table: "TournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_Matches_MatchId",
                table: "TournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_Teams_TeamId",
                table: "TournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_Tournaments_TournamentId",
                table: "TournamentTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentTeams",
                table: "TournamentTeams");

            migrationBuilder.RenameTable(
                name: "TournamentTeams",
                newName: "TournamentTeam");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_TournamentId",
                table: "TournamentTeam",
                newName: "IX_TournamentTeam_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_TeamId",
                table: "TournamentTeam",
                newName: "IX_TournamentTeam_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_MatchId",
                table: "TournamentTeam",
                newName: "IX_TournamentTeam_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_GroupId",
                table: "TournamentTeam",
                newName: "IX_TournamentTeam_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentTeam",
                table: "TournamentTeam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TournamentTeam_WinnerId",
                table: "Games",
                column: "WinnerId",
                principalTable: "TournamentTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TournamentTeam_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "TournamentTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeam_Group_GroupId",
                table: "TournamentTeam",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeam_Matches_MatchId",
                table: "TournamentTeam",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeam_Teams_TeamId",
                table: "TournamentTeam",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeam_Tournaments_TournamentId",
                table: "TournamentTeam",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
