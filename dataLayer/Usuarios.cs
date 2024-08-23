using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using entityLayer;

namespace dataLayer
{
    public class Usuarios
    {
        private SqlConnection connection;
        public Usuarios()
        {
            connection = new SqlConnection(Conexion.cnn);
        }

        public List<Usuario> ListarUsuarios() { 
                       
            List<Usuario> userList = new List<Usuario>();
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarUsuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Patron", "sdf");

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario user = new Usuario
                            {
                                IdUsuario = reader.GetInt32(0),
                                // llenar el reto de campos
                            };

                            userList.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la lista de usuarios");
            }
            finally { connection.Close(); }

            return userList;
        }
    }
}
