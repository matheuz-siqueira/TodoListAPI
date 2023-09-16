using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSubTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "SubTasks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SubTasks");
        }
    }
}
