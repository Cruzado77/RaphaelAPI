using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaphaelAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cartao",
                columns: table => new
                {
                    numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    data_expiracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bandeira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cvv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titular = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartao", x => x.numero);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produto_Id = table.Column<int>(type: "int", nullable: false),
                    cartaonumero = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    valor = table.Column<float>(type: "real", nullable: false),
                    qtde_comprada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compra_cartao_cartaonumero",
                        column: x => x.cartaonumero,
                        principalTable: "cartao",
                        principalColumn: "numero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compra_cartaonumero",
                table: "compra",
                column: "cartaonumero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compra");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "cartao");
        }
    }
}
