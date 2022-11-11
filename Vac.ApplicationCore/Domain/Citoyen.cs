using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vac.ApplicationCore.Domain
{
    public class Citoyen
    {
        public int citoyenId { get; set; }
        public int age { get; set; }

        [Key]
        public String cin { get; set; }
        public String nom { get; set; }

        [Required]
        public int numeroEvax { get; set; }
        public String prenom { get; set; }
        public int telephone { get; set; }
        public Adresse adresse { get; set; }

        public virtual ICollection<Vaccin> Vaccins { get; set; }
        public virtual ICollection<RendezVous> RendezVous { get; set; }

    }
}
