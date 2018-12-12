using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook.Db.Migrations
{
    public partial class NoFoodSynonym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Food_FoodId",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_FoodId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Food");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FoodId",
                table: "Food",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_FoodId",
                table: "Food",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Food_FoodId",
                table: "Food",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
