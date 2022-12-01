using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApInitial.Migrations
{
    public partial class APIversion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctoresHorario");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.RenameColumn(
                name: "UserContraseña",
                table: "Usuarios",
                newName: "UserPassword");

            migrationBuilder.AddColumn<DateTime>(
                name: "DocHorarioFinal",
                table: "Doctores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DocHorarioInicial",
                table: "Doctores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CtHorarioFinal",
                table: "Citas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CtHorarioInicial",
                table: "Citas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocHorarioFinal",
                table: "Doctores");

            migrationBuilder.DropColumn(
                name: "DocHorarioInicial",
                table: "Doctores");

            migrationBuilder.DropColumn(
                name: "CtHorarioFinal",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "CtHorarioInicial",
                table: "Citas");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Usuarios",
                newName: "UserContraseña");

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    HrCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HrEstatus = table.Column<string>(type: "varchar(1)", nullable: false),
                    HrFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HrIncio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HrCodigo);
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

            migrationBuilder.CreateIndex(
                name: "IX_DoctoresHorario_HorariosHrCodigo",
                table: "DoctoresHorario",
                column: "HorariosHrCodigo");
        }
    }
}
