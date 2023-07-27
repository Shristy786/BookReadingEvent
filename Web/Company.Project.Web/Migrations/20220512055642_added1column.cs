using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.Web.Migrations
{
    public partial class added1column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "CreateEvent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "CreateEvent");
        }
    }
}
