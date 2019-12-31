using Microsoft.EntityFrameworkCore.Migrations;

namespace Funparty.Api.Migrations
{
    public partial class AddMascotPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Mascots_MascotId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_MascotId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MascotId",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "MascotPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MascotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MascotPhoto_Mascots_MascotId",
                        column: x => x.MascotId,
                        principalTable: "Mascots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MascotPhoto_MascotId",
                table: "MascotPhoto",
                column: "MascotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MascotPhoto");

            migrationBuilder.AddColumn<int>(
                name: "MascotId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_MascotId",
                table: "Photos",
                column: "MascotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Mascots_MascotId",
                table: "Photos",
                column: "MascotId",
                principalTable: "Mascots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
