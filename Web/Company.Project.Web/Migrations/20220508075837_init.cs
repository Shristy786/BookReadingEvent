using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.CreateTable(
                name: "CreateEvent",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EventType = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    OtherDetails = table.Column<string>(nullable: true),
                    InviteByMail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateEvent", x => x.EventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateEvent");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Title);
                });
        }
    }
}
