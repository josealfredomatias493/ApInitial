using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApInitial.Migrations
{
    public partial class APPVer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctores",
                columns: table => new
                {
                    DocCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNombre = table.Column<string>(type: "varchar(200)", nullable: false),
                    DocApellido = table.Column<string>(type: "varchar(200)", nullable: false),
                    DocTelefono = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocEmail = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocEspecialidades = table.Column<string>(type: "varchar(200)", nullable: false),
                    DocEstatus = table.Column<string>(type: "varchar(1)", nullable: false),
                    DocUsuario = table.Column<string>(type: "varchar(50)", nullable: false),
                    DocPassword = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctores", x => x.DocCodigo);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    HrCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HrIncio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HrFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HrEstatus = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HrCodigo);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacNombre = table.Column<string>(type: "varchar(200)", nullable: false),
                    PacApellido = table.Column<string>(type: "varchar(200)", nullable: false),
                    PacFechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacTelefono = table.Column<string>(type: "varchar(15)", nullable: true),
                    PacEmail = table.Column<string>(type: "varchar(200)", nullable: true),
                    PacDireccion = table.Column<string>(type: "varchar(200)", nullable: false),
                    PacEstatus = table.Column<string>(type: "varchar(1)", nullable: false),
                    PacUsuario = table.Column<string>(type: "varchar(50)", nullable: false),
                    PacPassword = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacCodigo);
                });

            migrationBuilder.CreateTable(
                name: "DoctoresHorario",
                columns: table => new
                {
                    DoctoresDocCodigo = table.Column<int>(type: "int", nullable: false),
                    HorariosHrCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctoresHorario", x => new { x.DoctoresDocCodigo, x.HorariosHrCodigo });
                    table.ForeignKey(
                        name: "FK_DoctoresHorario_Doctores_DoctoresDocCodigo",
                        column: x => x.DoctoresDocCodigo,
                        principalTable: "Doctores",
                        principalColumn: "DocCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctoresHorario_Horarios_HorariosHrCodigo",
                        column: x => x.HorariosHrCodigo,
                        principalTable: "Horarios",
                        principalColumn: "HrCodigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CtCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacCodigo = table.Column<int>(type: "int", nullable: false),
                    CtDescripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    DocCodigo = table.Column<int>(type: "int", nullable: false),
                    CtEstatus = table.Column<string>(type: "varchar(1)", nullable: false),
                    CtHorario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CtCodigo);
                    table.ForeignKey(
                        name: "FK_Citas_Doctores_DocCodigo",
                        column: x => x.DocCodigo,
                        principalTable: "Doctores",
                        principalColumn: "DocCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_PacCodigo",
                        column: x => x.PacCodigo,
                        principalTable: "Pacientes",
                        principalColumn: "PacCodigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_DocCodigo",
                table: "Citas",
                column: "DocCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacCodigo",
                table: "Citas",
                column: "PacCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_DoctoresHorario_HorariosHrCodigo",
                table: "DoctoresHorario",
                column: "HorariosHrCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "DoctoresHorario");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Doctores");

            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
