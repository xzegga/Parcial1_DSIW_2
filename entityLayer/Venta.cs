using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityLayer
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Cliente Cliente { get; set; }
        public int TotalProductos { get; set; }
        public double MontoTotal { get; set; }
        public string Contacto { get; set; }
        public Distrito Distrito { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string FechaVenta { get; set; }
        public int IdTransaccion { get; set; }

    }
}
