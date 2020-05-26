using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAppWithSwagger.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItem", x => x.Id);
                });
            migrationBuilder.InsertData(
                "TodoItem",
                new[] { "Id", "name", "value" },
                    new object[] { 1, "Todo1", "value1" });
            migrationBuilder.InsertData(
                "TodoItem",
                new[] { "Id", "name", "value" },
                    new object[] { 2, "Todo2", "value2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItem");
        }
    }
}
