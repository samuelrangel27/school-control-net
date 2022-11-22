using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_control_net.DbContexts.Migrations
{
    public partial class renameAcademicValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AcamedicValue",
                table: "Classes",
                newName: "AcademicValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AcademicValue",
                table: "Classes",
                newName: "AcamedicValue");
        }
    }
}
