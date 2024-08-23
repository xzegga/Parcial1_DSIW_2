using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace entityLayer
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string NombreProducto { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Marca")]
        public int IdMarca { get; set; }

        public virtual Marca Marca { get; set; }

        [Display(Name = "Categoría")]
        public int IdCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }

        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Display(Name = "Stock Disponible")]
        public int Stock { get; set; }

        [Display(Name = "Ruta de la Imagen")]
        public string RutaImagen { get; set; }

        [Display(Name = "Nombre de la Imagen")]
        public string NombreImagen { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Display(Name = "Fecha de Registro")]
        public string FechaRegistro { get; set; }
        
    }
}
