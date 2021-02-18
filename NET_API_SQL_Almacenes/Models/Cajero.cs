using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Almacenes.Models {
    public partial class Cajero {
        public int Codigo { get; set; }
        public string NomApels { get; set; }
        public ICollection<Venta> Ventas { get; set; }
        public Cajero() {
            Ventas = new HashSet<Venta>();
        }
    }
}
