using Chaufferie.ChargesMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargeMS.Data.Context
{
    public class ChargesContext : DbContext
    {
        public ChargesContext(DbContextOptions<ChargesContext> options)
            : base(options)
        {
        }

        public DbSet<Filiale> Filiales { get; set; }
        public DbSet<ChPersonnel> ChPersonnels { get; set; }
        public DbSet<ChAssistExterne> ChAssistExeternes { get; set; }
        public DbSet<TypeIntervention> TypeInterventions { get; set; }
        public DbSet<BureauControle> BureauControles { get; set; }
        public DbSet<ChPieceRechange> ChPieceRechanges { get; set; }
        public DbSet<Consommable> Consommables { get; set; }
        public DbSet<TypeConsommable> TypeConsommables { get; set; }
        public DbSet<ChEau> ChConsommationsEau { get; set; }
        public DbSet<ChElectrique> chElectriques { get; set; }
        public DbSet<ChCombustible> chCombustibles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChPersonnel>()
                .HasOne(e => e.Filiale)
                .WithMany(e => e.ChPersonnels)
                .HasForeignKey(e => e.FkSubsidiary);

            modelBuilder.Entity<ChAssistExterne>()
               .HasOne(e => e.Filiale)
               .WithMany(e => e.ChAssistExeternes)
               .HasForeignKey(e => e.FkSubsidiary);

            modelBuilder.Entity<ChAssistExterne>()
                .HasOne(e => e.TypeIntervention)
                .WithMany(e => e.ChAssistExeternes)
                .HasForeignKey(e => e.FkTypeIntervention);

            modelBuilder.Entity<ChAssistExterne>()
                .HasOne(e => e.BureauControle)
                .WithMany(e => e.ChAssistExeternes)
                .HasForeignKey(e => e.FkBureauControle);

            modelBuilder.Entity<ChPieceRechange>()
              .HasOne(e => e.Filiale)
              .WithMany(e => e.ChPieceRechanges)
              .HasForeignKey(e => e.FkSubsidiary);

            modelBuilder.Entity<Consommable>()
            .HasOne(e => e.Filiale)
            .WithMany(e => e.Consommables)
            .HasForeignKey(e => e.FkSubsidiary);

            modelBuilder.Entity<ChEau>()
               .HasOne(e => e.Filiale)
               .WithMany(e => e.ChConsommationsEau)
               .HasForeignKey(e => e.FkSubsidiary);


            modelBuilder.Entity<ChAssistExterne>()
            .Property(p => p.SousTraitant)
            .IsRequired(false);

            modelBuilder.Entity<ChCombustible>()
               .HasOne(e => e.Filiale)
               .WithMany(e => e.ChCombustibles)
               .HasForeignKey(e => e.FkSubsidiary);

            modelBuilder.Entity<ChElectrique>()
              .HasOne(e => e.Filiale)
              .WithMany(e => e.ChElectriques)
              .HasForeignKey(e => e.FkSubsidiary);
        }


    }
}
