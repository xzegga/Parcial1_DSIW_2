using System.Collections.Generic;
using entityLayer;
using dataLayer;

namespace businessLayer
{
    public class ProductService
    {
        private readonly ProductRepository _productoRepository;

        public ProductService(ProductRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public IEnumerable<Producto> GetAllProducts()
        {
            return _productoRepository.GetAllProducts();
        }

        public Producto GetProductById(int id)
        {
            return _productoRepository.GetProductById(id);
        }

        public void CreateProduct(Producto producto)
        {
            // Puedes agregar lógica adicional aquí, como validaciones.
            _productoRepository.CreateProduct(producto);
        }

        public void UpdateProduct(Producto producto)
        {
            // Puedes agregar lógica adicional aquí, como validaciones.
            _productoRepository.UpdateProduct(producto);
        }

        public void DeleteProduct(int id)
        {
            // Puedes agregar lógica adicional aquí, como validaciones.
            _productoRepository.DeleteProduct(id);
        }
    }
}
