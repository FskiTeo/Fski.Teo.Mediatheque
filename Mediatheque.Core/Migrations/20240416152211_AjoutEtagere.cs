using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediatheque.Core.Migrations
{
    /// <inheritdoc />
    public partial class AjoutEtagere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EtagereId",
                table: "CD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Etagere",
                columns: table => new
                {
                    EtagereId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Emplacement = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etagere", x => x.EtagereId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CD_EtagereId",
                table: "CD",
                column: "EtagereId");

            migrationBuilder.AddForeignKey(
                name: "FK_CD_Etagere_EtagereId",
                table: "CD",
                column: "EtagereId",
                principalTable: "Etagere",
                principalColumn: "EtagereId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CD_Etagere_EtagereId",
                table: "CD");

            migrationBuilder.DropTable(
                name: "Etagere");

            migrationBuilder.DropIndex(
                name: "IX_CD_EtagereId",
                table: "CD");

            migrationBuilder.DropColumn(
                name: "EtagereId",
                table: "CD");
        }
    }
}
