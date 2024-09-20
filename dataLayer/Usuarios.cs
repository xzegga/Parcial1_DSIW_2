using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using entityLayer;

namespace dataLayer
{
    public class Usuarios
    {
        private readonly SqlConnection _connection;
        private readonly String _patron;

        public Usuarios(CustomConfigurationManager configManager)
        {
            _connection = new SqlConnection(configManager.connection);
            _patron = configManager.patron;
        }

        public List<Usuario> ListarUsuarios() { 
                       
            List<Usuario> userList = new List<Usuario>();
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarUsuarios", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Patron", _patron);

                    _connection.Open();
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
            finally { _connection.Close(); }

            return userList;
        }

        public void EditUser(Usuario user)
        {
            // Modify the user through a stored procedure SP_ModificarUsuario
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ModificarUsuario", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdUsuario", user.IdUsuario);
                    command.Parameters.AddWithValue("@Nombres", user.Nombres);
                    command.Parameters.AddWithValue("@Apellidos", user.Apellidos);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Reestablecer", user.Reestablecer);
                    command.Parameters.AddWithValue("@Estado", user.Estado);
                    command.Parameters.AddWithValue("@Fecha", user.Fecha);

                    _connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al modificar el usuario");
            }
            finally { _connection.Close(); }
        }
    }
}
