using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaCargoSRL.Models
{
    public class ClientModel
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string lastname { get; set; } = string.Empty;
        public string company { get; set; }
        public string phone { get; set; }
        public int? id_membership { get; set; }
    }
}
