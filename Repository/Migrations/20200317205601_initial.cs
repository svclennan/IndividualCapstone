using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "MoodTrackers",
                columns: table => new
                {
                    MoodTrackerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoodTrackers", x => x.MoodTrackerId);
                });

            migrationBuilder.CreateTable(
                name: "Moods",
                columns: table => new
                {
                    MoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoodRating = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    MoodTrackerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moods", x => x.MoodId);
                    table.ForeignKey(
                        name: "FK_Moods_MoodTrackers_MoodTrackerId",
                        column: x => x.MoodTrackerId,
                        principalTable: "MoodTrackers",
                        principalColumn: "MoodTrackerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistRatings",
                columns: table => new
                {
                    PlaylistRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistUrl = table.Column<string>(nullable: true),
                    Rating = table.Column<bool>(nullable: false),
                    MoodTrackerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistRatings", x => x.PlaylistRatingId);
                    table.ForeignKey(
                        name: "FK_PlaylistRatings_MoodTrackers_MoodTrackerId",
                        column: x => x.MoodTrackerId,
                        principalTable: "MoodTrackers",
                        principalColumn: "MoodTrackerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moods_MoodTrackerId",
                table: "Moods",
                column: "MoodTrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistRatings_MoodTrackerId",
                table: "PlaylistRatings",
                column: "MoodTrackerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Moods");

            migrationBuilder.DropTable(
                name: "PlaylistRatings");

            migrationBuilder.DropTable(
                name: "MoodTrackers");
        }
    }
}
