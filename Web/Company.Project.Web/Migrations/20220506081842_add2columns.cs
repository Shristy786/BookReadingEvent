using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.Web.Migrations
{
    public partial class add2columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateOn",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateOn",
                table: "Books");
        }
    }
}
