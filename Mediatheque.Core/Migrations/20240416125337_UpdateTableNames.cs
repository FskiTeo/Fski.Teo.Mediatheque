using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediatheque.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Jeux",
                table: "Jeux");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CDs",
                table: "CDs");

            migrationBuilder.RenameTable(
                name: "Jeux",
                newName: "JeuDeSociete");

            migrationBuilder.RenameTable(
                name: "CDs",
                newName: "CD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JeuDeSociete",
                table: "JeuDeSociete",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CD",
                table: "CD",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JeuDeSociete",
                table: "JeuDeSociete");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CD",
                table: "CD");

            migrationBuilder.RenameTable(
                name: "JeuDeSociete",
                newName: "Jeux");

            migrationBuilder.RenameTable(
                name: "CD",
                newName: "CDs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jeux",
                table: "Jeux",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CDs",
                table: "CDs",
                column: "Id");
        }
    }
}
