using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiVete.Migrations
{
    /// <inheritdoc />
    public partial class AddClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cat_clientes",
                columns: table => new
                {
                    eCodCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iCodEstatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_clientes", x => x.eCodCliente);
                });

            migrationBuilder.CreateTable(
                name: "cat_mascotas",
                columns: table => new
                {
                    eCodMascota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eCodCliente = table.Column<int>(type: "int", nullable: false),
                    dFechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    iSexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iPeso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iAlergias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iObservaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_mascotas", x => x.eCodMascota);
                });

            migrationBuilder.CreateTable(
                name: "cat_productos",
                columns: table => new
                {
                    eCodProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iPrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iStock = table.Column<int>(type: "int", nullable: false),
                    iCodEstatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_productos", x => x.eCodProducto);
                });

            migrationBuilder.CreateTable(
                name: "cat_ventas",
                columns: table => new
                {
                    eCodVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eCodCliente = table.Column<int>(type: "int", nullable: false),
                    eCodProducto = table.Column<int>(type: "int", nullable: false),
                    iCantidad = table.Column<int>(type: "int", nullable: false),
                    iPrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dFechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_ventas", x => x.eCodVenta);
                });

            migrationBuilder.CreateTable(
                name: "ret_consultas",
                columns: table => new
                {
                    eCodConsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eCodMascota = table.Column<int>(type: "int", nullable: false),
                    dFechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    iSintomas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iDiagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iTratamiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iObservaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iCosto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ret_consultas", x => x.eCodConsulta);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cat_clientes");

            migrationBuilder.DropTable(
                name: "cat_mascotas");

            migrationBuilder.DropTable(
                name: "cat_productos");

            migrationBuilder.DropTable(
                name: "cat_ventas");

            migrationBuilder.DropTable(
                name: "ret_consultas");
        }
    }
}
