using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal_API.Migrations
{
    public partial class cv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileCV",
                table: "Candidato");

            migrationBuilder.CreateTable(
                name: "FileCV",
                columns: table => new
                {
                    IdFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IdCandidatoFile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileCV", x => x.IdFile);
                    table.ForeignKey(
                        name: "FK_FileCV_Candidato_IdCandidatoFile",
                        column: x => x.IdCandidatoFile,
                        principalTable: "Candidato",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileCV_IdCandidatoFile",
                table: "FileCV",
                column: "IdCandidatoFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileCV");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileCV",
                table: "Candidato",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
