using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Reservas.Models {
    public partial class Reserva {
        public string InvestigadorDNI { get; set; }
        public char EquipoNumReferencia { get; set; }
        public virtual Equipo Equipo { get; set; }
        public virtual Investigador Investigador { get; set; }
        public DateTime Comienzo { get; set; }
        public DateTime Fin { get; set; }
    }
}
