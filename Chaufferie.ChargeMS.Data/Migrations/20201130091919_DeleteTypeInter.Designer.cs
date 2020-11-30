﻿// <auto-generated />
using System;
using Chaufferie.ChargeMS.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    [DbContext(typeof(ChargesContext))]
    [Migration("20201130091919_DeleteTypeInter")]
    partial class DeleteTypeInter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.BureauControle", b =>
                {
                    b.Property<Guid>("BureauControleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BureauControleId");

                    b.ToTable("BureauControles");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChAssistExterne", b =>
                {
                    b.Property<Guid>("ChAssistExterneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FkBureauControle")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FkSubsidiary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Intervention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Montant")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SousTraitant")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChAssistExterneId");

                    b.HasIndex("FkBureauControle");

                    b.HasIndex("FkSubsidiary");

                    b.ToTable("ChAssistExeternes");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChCombustible", b =>
                {
                    b.Property<Guid>("ChCombustibleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("CoefficientDeCorrection")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FkSubsidiary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PCS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<decimal>("QuantiteConsomme")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ChCombustibleId");

                    b.HasIndex("FkSubsidiary");

                    b.ToTable("chCombustibles");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChEau", b =>
                {
                    b.Property<Guid>("ChEauId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FkSubsidiary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<bool>("PrixUnitaireOsmose")
                        .HasColumnType("bit");

                    b.Property<decimal>("QuantiteConsomme")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ChEauId");

                    b.HasIndex("FkSubsidiary");

                    b.ToTable("ChConsommationsEau");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChElectrique", b =>
                {
                    b.Property<Guid>("ChElectriqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FkSubsidiary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<decimal>("QuantiteConsomme")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("quantiteEauConsommee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("quantiteVapeurProduite")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("typeCalculConsommation")
                        .HasColumnType("int");

                    b.HasKey("ChElectriqueId");

                    b.HasIndex("FkSubsidiary");

                    b.ToTable("chElectriques");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChPersonnel", b =>
                {
                    b.Property<Guid>("ChPersonnelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FkSubsidiary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FkUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TauxOccupation")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ChPersonnelId");

                    b.HasIndex("FkSubsidiary");

                    b.ToTable("ChPersonnels");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChPieceRechange", b =>
                {
                    b.Property<Guid>("ChPieceRechangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FkSubsidiary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Montant")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomFournisseur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nombre")
                        .HasColumnType("int");

                    b.HasKey("ChPieceRechangeId");

                    b.HasIndex("FkSubsidiary");

                    b.ToTable("ChPieceRechanges");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.Consommable", b =>
                {
                    b.Property<Guid>("ConsommableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Consommation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FkSubsidiary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fournisseur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeConsommableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Unite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConsommableId");

                    b.HasIndex("FkSubsidiary");

                    b.HasIndex("TypeConsommableId");

                    b.ToTable("Consommables");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.Filiale", b =>
                {
                    b.Property<Guid>("subsidiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SecteurId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("UniteCombustible")
                        .HasColumnType("int");

                    b.Property<Guid?>("UniteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("logo")
                        .HasColumnType("tinyint");

                    b.Property<string>("subsidiaryCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("subsidiaryId");

                    b.ToTable("Filiales");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.TypeConsommable", b =>
                {
                    b.Property<Guid>("TypeConsommableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeConsommableId");

                    b.ToTable("TypeConsommables");
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChAssistExterne", b =>
                {
                    b.HasOne("Chaufferie.ChargesMS.Domain.Models.BureauControle", "BureauControle")
                        .WithMany("ChAssistExeternes")
                        .HasForeignKey("FkBureauControle");

                    b.HasOne("Chaufferie.ChargesMS.Domain.Models.Filiale", "Filiale")
                        .WithMany("ChAssistExeternes")
                        .HasForeignKey("FkSubsidiary")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChCombustible", b =>
                {
                    b.HasOne("Chaufferie.ChargesMS.Domain.Models.Filiale", "Filiale")
                        .WithMany("ChCombustibles")
                        .HasForeignKey("FkSubsidiary")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChEau", b =>
                {
                    b.HasOne("Chaufferie.ChargesMS.Domain.Models.Filiale", "Filiale")
                        .WithMany("ChConsommationsEau")
                        .HasForeignKey("FkSubsidiary")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChElectrique", b =>
                {
                    b.HasOne("Chaufferie.ChargesMS.Domain.Models.Filiale", "Filiale")
                        .WithMany("ChElectriques")
                        .HasForeignKey("FkSubsidiary")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChPersonnel", b =>
                {
                    b.HasOne("Chaufferie.ChargesMS.Domain.Models.Filiale", "Filiale")
                        .WithMany("ChPersonnels")
                        .HasForeignKey("FkSubsidiary")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.ChPieceRechange", b =>
                {
                    b.HasOne("Chaufferie.ChargesMS.Domain.Models.Filiale", "Filiale")
                        .WithMany("ChPieceRechanges")
                        .HasForeignKey("FkSubsidiary")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chaufferie.ChargesMS.Domain.Models.Consommable", b =>
                {
                    b.HasOne("Chaufferie.ChargesMS.Domain.Models.Filiale", "Filiale")
                        .WithMany("Consommables")
                        .HasForeignKey("FkSubsidiary")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chaufferie.ChargesMS.Domain.Models.TypeConsommable", "TypeConsommable")
                        .WithMany("Consommables")
                        .HasForeignKey("TypeConsommableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
