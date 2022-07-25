using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.Infrastructure.Migrations
{
    public partial class UpdateNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notification");
        }
    }
}
