using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymDataAccsess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoToMemebr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Members");
        }
    }
}
