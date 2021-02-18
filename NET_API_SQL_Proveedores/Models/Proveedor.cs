using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Proveedores.Models {
    public partial class Proveedor {
        public char Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Suministro> Suministros { get; set; }
        public Proveedor() {
            Suministros = new HashSet<Suministro>();
        }
    }
}
