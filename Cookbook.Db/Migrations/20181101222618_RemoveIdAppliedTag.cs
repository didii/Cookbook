using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook.Db.Migrations
{
    public partial class RemoveIdAppliedTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppliedTag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "AppliedTag",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
