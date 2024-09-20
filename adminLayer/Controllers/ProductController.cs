using adminLayer.Models;
using businessLayer;
using dataLayer;
using entityLayer;
using System.Web.Mvc;

namespace adminLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productoService;
        private readonly CustomConfigurationManager _configManager;

        public ProductController()
        {
            _configManager = new CustomConfigurationManager();
            _productoService = new ProductService(new ProductRepository(_configManager));

        }

        public ActionResult Index()
        {
            var productos = _productoService.GetAllProducts();
            return View(productos);
        }

        [HttpGet]
        public JsonResult GetProduct(int id)
        {
            var producto = _productoService.GetProductById(id);
            var viewModel = new ProductoViewModel
            {
                IdProducto = producto.IdProducto,
                NombreProducto = producto.NombreProducto,
                Descripcion = producto.Descripcion,
                IdMarca = producto.IdMarca,
                IdCategoria = producto.IdCategoria,
                Precio = producto.Precio,
                Stock = producto.Stock,
                Estado = producto.Estado
            };
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto
                {
                    NombreProducto = viewModel.NombreProducto,
                    Descripcion = viewModel.Descripcion,
                    IdMarca = viewModel.IdMarca,
                    IdCategoria = viewModel.IdCategoria,
                    Precio = viewModel.Precio,
                    Stock = viewModel.Stock,
                    Estado = viewModel.Estado
                };
                _productoService.CreateProduct(producto);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto
                {
                    IdProducto = viewModel.IdProducto,
                    NombreProducto = viewModel.NombreProducto,
                    Descripcion = viewModel.Descripcion,
                    IdMarca = viewModel.IdMarca,
                    IdCategoria = viewModel.IdCategoria,
                    Precio = viewModel.Precio,
                    Stock = viewModel.Stock,
                    Estado = viewModel.Estado
                };
                _productoService.UpdateProduct(producto);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            _productoService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
