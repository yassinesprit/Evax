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
    internal class CitoyenConfiguration : IEntityTypeConfiguration<Citoyen>
    {
        public void Configure(EntityTypeBuilder<Citoyen> builder)
        {
            builder.OwnsOne(a => a.adresse, addr =>
            {


                addr.Property(a => a.rue)
                .HasColumnName("Rue ");
                addr.Property(a => a.codePostal)
                        .IsRequired()
                        .HasColumnName("CodePostal");

                addr.Property(a => a.ville)
                       .IsRequired()
                       .HasColumnName("Ville");
            });
        }
    }

}
