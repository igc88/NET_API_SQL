using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Almacenes.Models {
    public partial class Producto {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public ICollection<Venta> Ventas { get; set; }
        public Producto() {
            Ventas = new HashSet<Venta>();
        }
    }
}
