using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Proveedores.Models {
    public partial class Pieza {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public ICollection<Suministro> Suministros { get; set; }
        public Pieza() {
            Suministros = new HashSet<Suministro>();
        }
    }
}
