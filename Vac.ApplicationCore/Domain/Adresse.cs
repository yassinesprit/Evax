using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vac.ApplicationCore.Domain
{
    public class Adresse
    {
        public int id { get; set; }
        public int codePostal { get; set; }
        public int rue { get; set; }
        public String ville { get; set; }
    }
}
