using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaphaelAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor_unitario = table.Column<float>(type: "real", nullable: false),
                    qtde_estoque = table.Column<int>(type: "int", nullable: false),
                    data_last = table.Column<DateTime>(type: "datetime2", nullable: true),
                    valor_last = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produto");
        }
    }
}
