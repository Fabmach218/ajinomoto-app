using Microsoft.EntityFrameworkCore.Migrations;

namespace ajinomoto_app.Data.Migrations
{
    public partial class DropColumnStatusPedidoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "t_pedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "t_pedido",
                type: "text",
                nullable: true);
        }
    }
}
