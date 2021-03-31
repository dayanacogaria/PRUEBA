using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_S.Migrations
{
    public partial class Prueba_SContextDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CodCliente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NomCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CodCliente);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodProducto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NomProducto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodProducto);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductoCodProducto = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ClienteCodCliente = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteCodCliente",
                        column: x => x.ClienteCodCliente,
                        principalTable: "Clientes",
                        principalColumn: "CodCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_Productos_ProductoCodProducto",
                        column: x => x.ProductoCodProducto,
                        principalTable: "Productos",
                        principalColumn: "CodProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteCodCliente",
                table: "Ventas",
                column: "ClienteCodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ProductoCodProducto",
                table: "Ventas",
                column: "ProductoCodProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
