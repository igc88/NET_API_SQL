using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Cientificos.Models {
    public partial class Cientifico {        
        public string DNI { get; set; }
        public string NomApels { get; set; }
        public ICollection<Asignacion> Asignaciones { get; set; } 
        public Cientifico() {
            Asignaciones = new HashSet<Asignacion>();
        }
    }
}
