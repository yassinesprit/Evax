using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vac.ApplicationCore.Domain
{
    public class Vaccin
    {
        public int vaccinId { get; set; }

        [DataType(DataType.Date)]
        public DateTime dateValidite { get; set; }
        public String fournisseur { get; set; }
        public int quantite { get; set; }
        public TypeVaccin typeVaccin { get; set; }

        public virtual ICollection<Citoyen> Citoyens { get; set; }
        public virtual ICollection<RendezVous> RendezVous { get; set; }
    }
}
