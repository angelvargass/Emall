using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public class Regla : BaseEntity {
        public int Id { get; set;  }
        public int SucursalId { get; set; }
        public string Detalle { get; set; }
    }
}
