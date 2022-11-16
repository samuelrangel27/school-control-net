using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_control_net.DbContexts.Migrations
{
    public partial class WeeklyHours_Classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeeklyHours",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeeklyHours",
                table: "Classes");
        }
    }
}
