using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Intcreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_AuthorUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_AuthorUserId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Blogs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Blogs");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorUserId",
                table: "Blogs",
                column: "AuthorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_AuthorUserId",
                table: "Blogs",
                column: "AuthorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
