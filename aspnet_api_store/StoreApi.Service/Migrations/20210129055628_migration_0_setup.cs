using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApi.Service.Migrations
{
    public partial class migration_0_setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReaderEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Topics_Readers_ReaderEntityId",
                        column: x => x.ReaderEntityId,
                        principalTable: "Readers",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    ArticleAuthorEntityId = table.Column<long>(type: "bigint", nullable: true),
                    ArticleTopicEntityId = table.Column<long>(type: "bigint", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditeddDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_ArticleAuthorEntityId",
                        column: x => x.ArticleAuthorEntityId,
                        principalTable: "Authors",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Topics_ArticleTopicEntityId",
                        column: x => x.ArticleTopicEntityId,
                        principalTable: "Topics",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "EntityId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1L, "chedro.cardenas@yahoo.com", "Chedro Cardenas", "12345" },
                    { 2L, "elliott.lockwood@aol.com", "Elliott Lockwood", "12345" },
                    { 3L, "joshwin.greene@gmail.com", "Joshwin Greene", "12345" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "EntityId", "Name", "ReaderEntityId" },
                values: new object[,]
                {
                    { 1L, "Startups", null },
                    { 2L, "DevOps", null },
                    { 3L, "Testing", null },
                    { 4L, "Big Data", null },
                    { 5L, "Machine Learning", null },
                    { 6L, "FAANG", null },
                    { 7L, "Languages", null },
                    { 8L, "Hacker News", null },
                    { 9L, "Databases", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleAuthorEntityId",
                table: "Articles",
                column: "ArticleAuthorEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleTopicEntityId",
                table: "Articles",
                column: "ArticleTopicEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ReaderEntityId",
                table: "Topics",
                column: "ReaderEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Readers");
        }
    }
}
