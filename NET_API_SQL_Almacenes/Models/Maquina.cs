using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Almacenes.Models {
    public class Maquina {
        public int Codigo { get; set; }
        public int Piso { get; set; }
        public ICollection<Venta> Ventas { get; set; }
        public Maquina() {
            Ventas = new HashSet<Venta>();
        }
    }
}
