using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Userpermissions",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PermissionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userpermissions", x => new { x.UserId, x.PermissionId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Userpermissions");
        }
    }
}
