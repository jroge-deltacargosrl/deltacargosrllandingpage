using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaCargoSRL.Models
{
    public class RouteModel
    {
        public int id { get; set; }
        public string pais { get; set; }
        public string descripcion { get; set; } = "";
        public bool marcado { get; set; }

    }
}
