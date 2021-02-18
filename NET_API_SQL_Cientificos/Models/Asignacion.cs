using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Cientificos.Models {
    public partial class Asignacion {
        public string CientificoDNI { get; set; }
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual Cientifico Cientifico { get; set; }
    }
}
