using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediatheque.Core.Migrations
{
    /// <inheritdoc />
    public partial class AjoutEtagere2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CD_Etagere_EtagereId",
                table: "CD");

            migrationBuilder.AlterColumn<int>(
                name: "EtagereId",
                table: "CD",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CD_Etagere_EtagereId",
                table: "CD",
                column: "EtagereId",
                principalTable: "Etagere",
                principalColumn: "EtagereId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CD_Etagere_EtagereId",
                table: "CD");

            migrationBuilder.AlterColumn<int>(
                name: "EtagereId",
                table: "CD",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CD_Etagere_EtagereId",
                table: "CD",
                column: "EtagereId",
                principalTable: "Etagere",
                principalColumn: "EtagereId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
