using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studentmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToStudentAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "students",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "students");
        }
    }
}
