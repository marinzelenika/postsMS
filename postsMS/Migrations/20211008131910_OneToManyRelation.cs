using Microsoft.EntityFrameworkCore.Migrations;

namespace postsMS.Migrations
{
    public partial class OneToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoFeedPosts");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "FeedModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FeedModel_PostId",
                table: "FeedModel",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedModel_Posts_PostId",
                table: "FeedModel",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedModel_Posts_PostId",
                table: "FeedModel");

            migrationBuilder.DropIndex(
                name: "IX_FeedModel_PostId",
                table: "FeedModel");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "FeedModel");

            migrationBuilder.CreateTable(
                name: "PhotoFeedPosts",
                columns: table => new
                {
                    photosId = table.Column<int>(type: "int", nullable: false),
                    postsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoFeedPosts", x => new { x.photosId, x.postsId });
                    table.ForeignKey(
                        name: "FK_PhotoFeedPosts_FeedModel_photosId",
                        column: x => x.photosId,
                        principalTable: "FeedModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoFeedPosts_Posts_postsId",
                        column: x => x.postsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoFeedPosts_postsId",
                table: "PhotoFeedPosts",
                column: "postsId");
        }
    }
}
