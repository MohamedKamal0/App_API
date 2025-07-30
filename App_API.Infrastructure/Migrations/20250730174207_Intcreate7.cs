using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Intcreate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorUserId",
                table: "Blogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorUserId",
                table: "Blogs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
