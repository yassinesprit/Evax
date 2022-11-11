using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vac.ApplicationCore.Domain
{
    public class RendezVous
    {
        public String codeInfirmiere { get; set; }
        public DateTime dateVaccination { get; set; }
        public int nbrDoses { get; set; }
         
        public virtual Citoyen Citoyen { get; set; }
        public virtual Vaccin Vaccin { get; set; }

        public int vaccinId { get; set; }
        public String citoyenId { get; set; }

    }
}
