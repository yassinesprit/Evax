using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vac.ApplicationCore.Domain
{
    public class CentreVaccination
    {
        public int centreVaccinationId { get; set; }
        public int capacite { get; set; }
        public int nbrChaises { get; set; }
        public int numTelephone { get; set; }
        public String responsableCentre { get; set; }
    }
}
