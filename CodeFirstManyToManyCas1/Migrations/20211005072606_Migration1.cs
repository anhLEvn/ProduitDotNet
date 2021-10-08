using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstManyToManyCas1.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activites_Adherents_AdherentId",
                table: "Activites");

            migrationBuilder.DropIndex(
                name: "IX_Activites_AdherentId",
                table: "Activites");

            migrationBuilder.DropColumn(
                name: "AdherentId",
                table: "Activites");

            migrationBuilder.CreateTable(
                name: "ActiviteAdherent",
                columns: table => new
                {
                    ActivitesId = table.Column<int>(type: "int", nullable: false),
                    AdherentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiviteAdherent", x => new { x.ActivitesId, x.AdherentsId });
                    table.ForeignKey(
                        name: "FK_ActiviteAdherent_Activites_ActivitesId",
                        column: x => x.ActivitesId,
                        principalTable: "Activites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiviteAdherent_Adherents_AdherentsId",
                        column: x => x.AdherentsId,
                        principalTable: "Adherents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiviteAdherent_AdherentsId",
                table: "ActiviteAdherent",
                column: "AdherentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiviteAdherent");

            migrationBuilder.AddColumn<int>(
                name: "AdherentId",
                table: "Activites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activites_AdherentId",
                table: "Activites",
                column: "AdherentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activites_Adherents_AdherentId",
                table: "Activites",
                column: "AdherentId",
                principalTable: "Adherents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
