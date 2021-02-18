using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Reservas.Models {
    public partial class Equipo {
        public char NumSerie { get; set; }
        public string Nombre { get; set; }
        public int IdFacultad { get; set; }
        public Facultad Facultad { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public Equipo() {
            Reservas = new HashSet<Reserva>();
        }
    }
}
