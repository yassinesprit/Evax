using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vac.Infrastructure.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codePostal = table.Column<int>(type: "int", nullable: false),
                    rue = table.Column<int>(type: "int", nullable: false),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "centreVaccinations",
                columns: table => new
                {
                    centreVaccinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacite = table.Column<int>(type: "int", nullable: false),
                    nbrChaises = table.Column<int>(type: "int", nullable: false),
                    numTelephone = table.Column<int>(type: "int", nullable: false),
                    responsableCentre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centreVaccinations", x => x.centreVaccinationId);
                });

            migrationBuilder.CreateTable(
                name: "vaccins",
                columns: table => new
                {
                    vaccinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateValidite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fournisseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantite = table.Column<int>(type: "int", nullable: false),
                    typeVaccin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccins", x => x.vaccinId);
                });

            migrationBuilder.CreateTable(
                name: "citoyens",
                columns: table => new
                {
                    cin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    citoyenId = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroEvax = table.Column<int>(type: "int", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<int>(type: "int", nullable: false),
                    adresseid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citoyens", x => x.cin);
                    table.ForeignKey(
                        name: "FK_citoyens_adresses_adresseid",
                        column: x => x.adresseid,
                        principalTable: "adresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitoyenVaccin",
                columns: table => new
                {
                    Citoyenscin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VaccinsvaccinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitoyenVaccin", x => new { x.Citoyenscin, x.VaccinsvaccinId });
                    table.ForeignKey(
                        name: "FK_CitoyenVaccin_citoyens_Citoyenscin",
                        column: x => x.Citoyenscin,
                        principalTable: "citoyens",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitoyenVaccin_vaccins_VaccinsvaccinId",
                        column: x => x.VaccinsvaccinId,
                        principalTable: "vaccins",
                        principalColumn: "vaccinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rendezVous",
                columns: table => new
                {
                    dateVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vaccinId = table.Column<int>(type: "int", nullable: false),
                    citoyenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codeInfirmiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nbrDoses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rendezVous", x => new { x.dateVaccination, x.citoyenId, x.vaccinId });
                    table.ForeignKey(
                        name: "FK_rendezVous_citoyens_citoyenId",
                        column: x => x.citoyenId,
                        principalTable: "citoyens",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rendezVous_vaccins_vaccinId",
                        column: x => x.vaccinId,
                        principalTable: "vaccins",
                        principalColumn: "vaccinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_citoyens_adresseid",
                table: "citoyens",
                column: "adresseid");

            migrationBuilder.CreateIndex(
                name: "IX_CitoyenVaccin_VaccinsvaccinId",
                table: "CitoyenVaccin",
                column: "VaccinsvaccinId");

            migrationBuilder.CreateIndex(
                name: "IX_rendezVous_citoyenId",
                table: "rendezVous",
                column: "citoyenId");

            migrationBuilder.CreateIndex(
                name: "IX_rendezVous_vaccinId",
                table: "rendezVous",
                column: "vaccinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "centreVaccinations");

            migrationBuilder.DropTable(
                name: "CitoyenVaccin");

            migrationBuilder.DropTable(
                name: "rendezVous");

            migrationBuilder.DropTable(
                name: "citoyens");

            migrationBuilder.DropTable(
                name: "vaccins");

            migrationBuilder.DropTable(
                name: "adresses");
        }
    }
}
