using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook.Db.Migrations
{
    public partial class IsBaseQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBaseQuantity",
                table: "Quantity",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBaseQuantity",
                table: "Quantity");
        }
    }
}
