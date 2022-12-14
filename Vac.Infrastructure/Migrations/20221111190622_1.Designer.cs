// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vac.Infrastructure;

#nullable disable

namespace Vac.Infrastructure.Migrations
{
    [DbContext(typeof(VacContext))]
    [Migration("20221111190622_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CitoyenVaccin", b =>
                {
                    b.Property<string>("Citoyenscin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VaccinsvaccinId")
                        .HasColumnType("int");

                    b.HasKey("Citoyenscin", "VaccinsvaccinId");

                    b.HasIndex("VaccinsvaccinId");

                    b.ToTable("CitoyenVaccin");
                });

            modelBuilder.Entity("Vac.ApplicationCore.Domain.Adresse", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("codePostal")
                        .HasColumnType("int");

                    b.Property<int>("rue")
                        .HasColumnType("int");

                    b.Property<string>("ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("adresses");
                });

            modelBuilder.Entity("Vac.ApplicationCore.Domain.CentreVaccination", b =>
                {
                    b.Property<int>("centreVaccinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("centreVaccinationId"), 1L, 1);

                    b.Property<int>("capacite")
                        .HasColumnType("int");

                    b.Property<int>("nbrChaises")
                        .HasColumnType("int");

                    b.Property<int>("numTelephone")
                        .HasColumnType("int");

                    b.Property<string>("responsableCentre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("centreVaccinationId");

                    b.ToTable("centreVaccinations");
                });

            modelBuilder.Entity("Vac.ApplicationCore.Domain.Citoyen", b =>
                {
                    b.Property<string>("cin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("adresseid")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<int>("citoyenId")
                        .HasColumnType("int");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numeroEvax")
                        .HasColumnType("int");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telephone")
                        .HasColumnType("int");

                    b.HasKey("cin");

                    b.HasIndex("adresseid");

                    b.ToTable("citoyens");
                });

            modelBuilder.Entity("Vac.ApplicationCore.Domain.RendezVous", b =>
                {
                    b.Property<DateTime>("dateVaccination")
                        .HasColumnType("datetime2");

                    b.Property<string>("citoyenId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("vaccinId")
                        .HasColumnType("int");

                    b.Property<string>("codeInfirmiere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nbrDoses")
                        .HasColumnType("int");

                    b.HasKey("dateVaccination", "citoyenId", "vaccinId");

                    b.HasIndex("citoyenId");

                    b.HasIndex("vaccinId");

                    b.ToTable("rendezVous");
                });

            modelBuilder.Entity("Vac.ApplicationCore.Domain.Vaccin", b =>
                {
                    b.Property<int>("vaccinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vaccinId"), 1L, 1);

                    b.Property<DateTime>("dateValidite")
                        .HasColumnType("datetime2");

                    b.Property<string>("fournisseur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantite")
                        .HasColumnType("int");

                    b.Property<int>("typeVaccin")
                        .HasColumnType("int");

                    b.HasKey("vaccinId");

                    b.ToTable("vaccins");
                });

            modelBuilder.Entity("CitoyenVaccin", b =>
                {
                    b.HasOne("Vac.ApplicationCore.Domain.Citoyen", null)
                        .WithMany()
                        .HasForeignKey("Citoyenscin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vac.ApplicationCore.Domain.Vaccin", null)
                        .WithMany()
                        .HasForeignKey("VaccinsvaccinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vac.ApplicationCore.Domain.Citoyen", b =>
                {
                    b.HasOne("Vac.ApplicationCore.Domain.Adresse", "adresse")
                        .WithMany()
                        .HasForeignKey("adresseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("adresse");
                });

            modelBuilder.Entity("Vac.ApplicationCore.Domain.RendezVous", b =>
                {
                    b.HasOne("Vac.ApplicationCore.Domain.Citoyen", "Citoyen")
                        .WithMany("RendezVous")
                        .HasForeignKey("citoyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vac.ApplicationCore.Domain.Vaccin", "Vaccin")
                        .WithMany("RendezVous")
                        .HasForeignKey("vaccinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citoyen");

                    b.Navigation("Vaccin");
                });

            modelBuilder.Entity("Vac.ApplicationCore.Domain.Citoyen", b =>
                {
                    b.Navigation("RendezVous");
                });

            modelBuilder.Entity("Vac.ApplicationCore.Domain.Vaccin", b =>
                {
                    b.Navigation("RendezVous");
                });
#pragma warning restore 612, 618
        }
    }
}
