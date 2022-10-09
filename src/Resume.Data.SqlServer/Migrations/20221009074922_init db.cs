using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Data.SqlServer.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false, comment: "Identity server user identifier"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SiteTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SiteTitleEn = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Intro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Period = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Star"),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLinks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Href = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "None"),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Self"),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLinks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserMedias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "application/octet-stream"),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMedias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSns",
                columns: table => new
                {
                    ServiceName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSns", x => new { x.UserId, x.ServiceName });
                    table.ForeignKey(
                        name: "FK_UserSns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContentLinks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ContentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Href = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "None"),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Self"),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentLinks_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentLinks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentMedias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ContentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "application/octet-stream"),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentMedias_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentMedias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Score = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ScoreMax = table.Column<double>(type: "float", nullable: false, defaultValue: 100.0),
                    SkillGroupId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_SkillGroups_SkillGroupId",
                        column: x => x.SkillGroupId,
                        principalTable: "SkillGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Skills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContentTags",
                columns: table => new
                {
                    ContentId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTags", x => new { x.ContentId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ContentTags_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentLinks_ContentId",
                table: "ContentLinks",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentLinks_UserId",
                table: "ContentLinks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentMedias_ContentId",
                table: "ContentMedias",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentMedias_UserId",
                table: "ContentMedias",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_UserId",
                table: "Contents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentTags_TagId",
                table: "ContentTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillGroups_UserId",
                table: "SkillGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillGroupId",
                table: "Skills",
                column: "SkillGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserId",
                table: "Skills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId",
                table: "Tags",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLinks_UserId",
                table: "UserLinks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMedias_UserId",
                table: "UserMedias",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentLinks");

            migrationBuilder.DropTable(
                name: "ContentMedias");

            migrationBuilder.DropTable(
                name: "ContentTags");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "UserLinks");

            migrationBuilder.DropTable(
                name: "UserMedias");

            migrationBuilder.DropTable(
                name: "UserSns");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "SkillGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
