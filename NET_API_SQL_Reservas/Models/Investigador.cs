using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Reservas.Models {
    public partial class Investigador {
        public string DNI { get; set; }
        public string NomApels { get; set; }
        public int IdFacultad { get; set; }
        public Facultad Facultad { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public Investigador() {
            Reservas = new HashSet<Reserva>();
        }
    }
}
