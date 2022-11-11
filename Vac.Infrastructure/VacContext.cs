using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vac.ApplicationCore.Domain;
using Vac.Infrastructure.Configuration;

namespace Vac.Infrastructure
{
    public class VacContext : DbContext
    {
        public DbSet<Vaccin> vaccins { get; set; }
        public DbSet<Citoyen> citoyens { get; set; }
        public DbSet<RendezVous> rendezVous { get; set; }
        public DbSet<Adresse> adresses { get; set; }
        public DbSet<CentreVaccination> centreVaccinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=vaccin_Yassine_BenSalah;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RendezVousConfiguration());
        }
    }
}
