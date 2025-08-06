using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem");

            migrationBuilder.RenameTable(
                name: "ToDoItem",
                newName: "ToDoItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems");

            migrationBuilder.RenameTable(
                name: "ToDoItems",
                newName: "ToDoItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem",
                column: "id");
        }
    }
}
