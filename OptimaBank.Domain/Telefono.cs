using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimaBank.Domain
{
    public class Telefono : Entity
    {
        public int TipoId { get; set; }

        public string Numero { get; set; }
    }
}
