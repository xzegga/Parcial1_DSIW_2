using System.ComponentModel.DataAnnotations;


namespace adminLayer.Models
{
    public class ProductoViewModel
    {
        public int IdProducto { get; set; }

        [Display(Name = "Nombre del Producto")]
        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        public string NombreProducto { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "La marca es requerida.")]
        public int IdMarca { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "La categoría es requerida.")]
        public int IdCategoria { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }

        [Display(Name = "Stock Disponible")]
        [Required(ErrorMessage = "El stock es requerido.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }
    }
}