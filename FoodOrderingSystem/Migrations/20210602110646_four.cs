using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrderingSystem.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsertionDateTime",
                table: "Registrations",
                newName: "InsertedDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsertedDateTime",
                table: "Registrations",
                newName: "InsertionDateTime");
        }
    }
}
