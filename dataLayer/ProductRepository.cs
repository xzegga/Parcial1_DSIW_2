using entityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace dataLayer
{
    public class ProductRepository
    {
        private readonly SqlConnection _SqlConnection;
        private readonly String _patron;

        public ProductRepository(CustomConfigurationManager configManager)
        {
            _SqlConnection = new SqlConnection(configManager.connection);
            _patron = configManager.patron;
        }

        public IEnumerable<Producto> GetAllProducts()
        {
            var productos = new List<Producto>();

            using (var connection = _SqlConnection)
            {
                using (var command = new SqlCommand("SP_GetAllProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
                            {
                                IdProducto = reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : 0,
                                NombreProducto = reader["NombreProducto"] != DBNull.Value ? reader["NombreProducto"].ToString() : string.Empty,
                                Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : string.Empty,
                                IdMarca = reader["IdMarca"] != DBNull.Value ? Convert.ToInt32(reader["IdMarca"]) : 0,
                                IdCategoria = reader["IdCategoria"] != DBNull.Value ? Convert.ToInt32(reader["IdCategoria"]) : 0,
                                Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0m,
                                Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0,
                                Estado = reader["Estado"] != DBNull.Value ? Convert.ToBoolean(reader["Estado"]) : false,
                                FechaRegistro = reader["FechaRegistro"] != DBNull.Value ? reader["FechaRegistro"].ToString() : string.Empty,
                                // Asignar Marca y Categoria
                                Marca = new Marca
                                {
                                    IdMarca = reader["IdMarca"] != DBNull.Value ? Convert.ToInt32(reader["IdMarca"]) : 0,
                                    NombreMarca = reader["Marca"] != DBNull.Value ? reader["Marca"].ToString() : string.Empty
                                },
                                Categoria = new Categoria
                                {
                                    IdCategoria = reader["IdCategoria"] != DBNull.Value ? Convert.ToInt32(reader["IdCategoria"]) : 0,
                                    DescripcionCategoria = reader["Categoria"] != DBNull.Value ? reader["Categoria"].ToString() : string.Empty
                                }
                            });
                        }
                    }
                }
            }

            return productos;
        }

        public Producto GetProductById(int id)
        {
            Producto producto = null;

            using (var connection = _SqlConnection)
            {
                using (var command = new SqlCommand("SP_GetProductById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", id);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Producto
                            {
                                IdProducto = reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : 0,
                                NombreProducto = reader["NombreProducto"] != DBNull.Value ? reader["NombreProducto"].ToString() : string.Empty,
                                Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : string.Empty,
                                IdMarca = reader["IdMarca"] != DBNull.Value ? Convert.ToInt32(reader["IdMarca"]) : 0,
                                IdCategoria = reader["IdCategoria"] != DBNull.Value ? Convert.ToInt32(reader["IdCategoria"]) : 0,
                                Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0m,
                                Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0,
                                Estado = reader["Estado"] != DBNull.Value ? Convert.ToBoolean(reader["Estado"]) : false,
                                FechaRegistro = reader["FechaRegistro"] != DBNull.Value ? reader["FechaRegistro"].ToString() : string.Empty
                            };
                        }
                    }
                }
            }

            return producto;
        }


        public void CreateProduct(Producto producto)
        {
            using (var connection = _SqlConnection)
            {
                using (var command = new SqlCommand("SP_CreateProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@IdMarca", producto.IdMarca);
                    command.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@Estado", producto.Estado);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(Producto producto)
        {
            using (var connection = _SqlConnection)
            {
                using (var command = new SqlCommand("SP_UpdateProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    command.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@IdMarca", producto.IdMarca);
                    command.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@Estado", producto.Estado);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int id)
        {
            using (var connection = _SqlConnection)
            {
                using (var command = new SqlCommand("SP_DeleteProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
