using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Almacenes.Models {
    public partial class Venta {
        public int IdProducto { get; set; }
        public int IdCajero { get; set; }
        public int IdMaquina { get; set; }
        public virtual Cajero Cajero { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Maquina Maquina { get; set; }
    }
}
