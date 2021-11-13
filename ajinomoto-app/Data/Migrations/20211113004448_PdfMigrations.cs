using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ajinomoto_app.Data.Migrations
{
    public partial class PdfMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "archivo",
                table: "t_pedido",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "archivo",
                table: "t_pedido");
        }
    }
}
