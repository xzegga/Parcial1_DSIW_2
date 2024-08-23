using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityLayer
{
    internal class VentaDetalle
    {
        //[IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [TotalDetalle]

        public int IdDetalleVenta { get; set; }
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }        
        public int Cantidad { get; set; }
        public double TotalDetalle { get; set; }

    }
}
