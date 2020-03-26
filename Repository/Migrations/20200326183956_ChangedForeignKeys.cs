using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ChangedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moods_MoodTrackers_MoodTrackerId",
                table: "Moods");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistRatings_MoodTrackers_MoodTrackerId",
                table: "PlaylistRatings");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistRatings_MoodTrackerId",
                table: "PlaylistRatings");

            migrationBuilder.DropIndex(
                name: "IX_Moods_MoodTrackerId",
                table: "Moods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PlaylistRatings_MoodTrackerId",
                table: "PlaylistRatings",
                column: "MoodTrackerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moods_MoodTrackerId",
                table: "Moods",
                column: "MoodTrackerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Moods_MoodTrackers_MoodTrackerId",
                table: "Moods",
                column: "MoodTrackerId",
                principalTable: "MoodTrackers",
                principalColumn: "MoodTrackerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistRatings_MoodTrackers_MoodTrackerId",
                table: "PlaylistRatings",
                column: "MoodTrackerId",
                principalTable: "MoodTrackers",
                principalColumn: "MoodTrackerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
