using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityLayer
{
    internal class Distrito
    {
        public int IdDistrito { get; set; }
        public string NombreDistrito { get; set; }
        public Departamento Departamento { get; set; }
        public int IdDepto { get; set; }

    }
}
