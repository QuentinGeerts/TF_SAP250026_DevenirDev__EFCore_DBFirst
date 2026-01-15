using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEFCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddFilmConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Creators_CreatorId",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Films",
                table: "Films");

            migrationBuilder.RenameTable(
                name: "Films",
                newName: "Film");

            migrationBuilder.RenameIndex(
                name: "IX_Films_CreatorId",
                table: "Film",
                newName: "IX_Film_CreatorId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Film",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReleasedYear",
                table: "Film",
                type: "int",
                nullable: false,
                comment: "L'année de sortie du film",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Film",
                table: "Film",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Film_ReleasedYear_Before1950",
                table: "Film",
                sql: "ReleasedYear >= 1950");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Creators_CreatorId",
                table: "Film",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Creators_CreatorId",
                table: "Film");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Film",
                table: "Film");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Film_ReleasedYear_Before1950",
                table: "Film");

            migrationBuilder.RenameTable(
                name: "Film",
                newName: "Films");

            migrationBuilder.RenameIndex(
                name: "IX_Film_CreatorId",
                table: "Films",
                newName: "IX_Films_CreatorId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "ReleasedYear",
                table: "Films",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "L'année de sortie du film");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Films",
                table: "Films",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Creators_CreatorId",
                table: "Films",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
