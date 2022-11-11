using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vac.ApplicationCore.Domain;

namespace Vac.Infrastructure.Configuration
{
    public class RendezVousConfiguration : IEntityTypeConfiguration<RendezVous>
    {

        public void Configure(EntityTypeBuilder<RendezVous> builder)
        {
            builder.HasKey(r => new
            {
                r.dateVaccination,
                r.citoyenId,
                r.vaccinId
            });

            builder.HasOne(rd => rd.Vaccin)
                .WithMany(v => v.RendezVous)
                .HasForeignKey(r => r.vaccinId);

            builder.HasOne(rd => rd.Citoyen)
                .WithMany(c => c.RendezVous)
                .HasForeignKey(r => r.citoyenId); 
        }
    }
}
