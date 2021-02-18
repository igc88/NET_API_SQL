using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Cientificos.Models {
    public partial class Proyecto {
        public int Id { get; set; }        
        public string Nombre { get; set; }
        public int Horas { get; set; }
        public ICollection<Asignacion> Asignaciones { get; set; }
        public Proyecto() {
            Asignaciones = new HashSet<Asignacion>();
        }
    }
}
