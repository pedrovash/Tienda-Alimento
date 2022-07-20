using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eva02Comida.Migrations
{
    public partial class primeraza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEdades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEdades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEspecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEspecies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFormatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFormatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMarcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMarcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "tblAlimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Porte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: true),
                    EdadId = table.Column<int>(type: "int", nullable: false),
                    EspecieId = table.Column<int>(type: "int", nullable: false),
                    FormatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAlimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAlimentos_tblEdades_EdadId",
                        column: x => x.EdadId,
                        principalTable: "tblEdades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAlimentos_tblEspecies_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "tblEspecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAlimentos_tblFormatos_FormatoId",
                        column: x => x.FormatoId,
                        principalTable: "tblFormatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAlimentos_tblMarcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "tblMarcas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAlimentos_EdadId",
                table: "tblAlimentos",
                column: "EdadId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAlimentos_EspecieId",
                table: "tblAlimentos",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAlimentos_FormatoId",
                table: "tblAlimentos",
                column: "FormatoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAlimentos_MarcaId",
                table: "tblAlimentos",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAlimentos");

            migrationBuilder.DropTable(
                name: "tblUsuarios");

            migrationBuilder.DropTable(
                name: "tblEdades");

            migrationBuilder.DropTable(
                name: "tblEspecies");

            migrationBuilder.DropTable(
                name: "tblFormatos");

            migrationBuilder.DropTable(
                name: "tblMarcas");
        }
    }
}
