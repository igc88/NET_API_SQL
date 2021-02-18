using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Proveedores.Models {
    public partial class Suministro {
        public int CodigoPieza { get; set; }
        public char ProveedorId { get; set; }
        public int Precio { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Pieza Pieza { get; set; }
    }
}
