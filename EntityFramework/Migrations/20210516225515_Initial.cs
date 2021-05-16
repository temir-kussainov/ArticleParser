using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParsersConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPathArticles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPathLinkArticle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPathTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPathBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPathDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsersConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ParsersConfigs",
                columns: new[] { "Id", "CreatedDate", "DateTimeFormat", "SiteLink", "UpdatedDate", "XPathArticles", "XPathBody", "XPathDateTime", "XPathLinkArticle", "XPathTitle" },
                values: new object[] { 1, new DateTime(2021, 5, 17, 4, 55, 14, 776, DateTimeKind.Local).AddTicks(2904), "dd M yyyy, HH:mm", "https://tengrinews.kz", null, "//div[@class='tn-main-news-item']", "//div[@class='tn-news-content']", "//h1[@class='tn-content-title']//span[@class='tn-hidden']", "//a[@class='tn-link']", "//h1[@class='tn-content-title']" });

            migrationBuilder.InsertData(
                table: "ParsersConfigs",
                columns: new[] { "Id", "CreatedDate", "DateTimeFormat", "SiteLink", "UpdatedDate", "XPathArticles", "XPathBody", "XPathDateTime", "XPathLinkArticle", "XPathTitle" },
                values: new object[] { 2, new DateTime(2021, 5, 17, 4, 55, 14, 776, DateTimeKind.Local).AddTicks(3336), "HH:mm, dd.MM.yyyy", "https://24.kz/ru/", null, "//div[@class='nspArt']", "//div[@class='itemBody']", "//ul//li[@class='itemDate']//time", "//a[@class='nspImageWrapper tleft fnull']", "//article[@class='view-article itemView']//div[@class='itemheader']//header//h1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "Login", "PasswordHash", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2021, 5, 17, 4, 55, 14, 774, DateTimeKind.Local).AddTicks(8344), "Jon", "Snow", "jon", "AQAAAAEAACcQAAAAEKOPbIyZyjFf6xY8FWjzMTOxW66msNg49k/41Z+z6TweZ6Ekl1Bn69HuEjKv1UWYgw==", null });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ParsersConfigs");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
