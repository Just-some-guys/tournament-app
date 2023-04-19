using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupStageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamNumberOneId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamNumberTwoId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_WinnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_WinnerId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Games_TeamNumberOneId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_TeamNumberTwoId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TeamNumberOneId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TeamNumberTwoId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "BracketType",
                table: "Brackets");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "TournamentTeam",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "TournamentTeam",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BracketType",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupStage_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupStageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_GroupStage_GroupStageId",
                        column: x => x.GroupStageId,
                        principalTable: "GroupStage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeam_GroupId",
                table: "TournamentTeam",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeam_MatchId",
                table: "TournamentTeam",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GroupId",
                table: "Matches",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_GroupStageId",
                table: "Group",
                column: "GroupStageId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStage_TournamentId",
                table: "GroupStage",
                column: "TournamentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TournamentTeam_WinnerId",
                table: "Games",
                column: "WinnerId",
                principalTable: "TournamentTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Group_GroupId",
                table: "Matches",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_TournamentTeam_WinnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Group_GroupId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TournamentTeam_WinnerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeam_Group_GroupId",
                table: "TournamentTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeam_Matches_MatchId",
                table: "TournamentTeam");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "GroupStage");

            migrationBuilder.DropIndex(
                name: "IX_TournamentTeam_GroupId",
                table: "TournamentTeam");

            migrationBuilder.DropIndex(
                name: "IX_TournamentTeam_MatchId",
                table: "TournamentTeam");

            migrationBuilder.DropIndex(
                name: "IX_Matches_GroupId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "TournamentTeam");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "TournamentTeam");

            migrationBuilder.DropColumn(
                name: "BracketType",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Matches");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeamNumberOneId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamNumberTwoId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BracketType",
                table: "Brackets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participant_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamNumberOneId",
                table: "Games",
                column: "TeamNumberOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamNumberTwoId",
                table: "Games",
                column: "TeamNumberTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_MatchId",
                table: "Participant",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_TeamId",
                table: "Participant",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_TeamNumberOneId",
                table: "Games",
                column: "TeamNumberOneId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_TeamNumberTwoId",
                table: "Games",
                column: "TeamNumberTwoId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_WinnerId",
                table: "Games",
                column: "WinnerId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
