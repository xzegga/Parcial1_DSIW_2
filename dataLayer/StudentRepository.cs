using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using entityLayer; 

namespace dataLayer
{
    public class StudentRepository
    {
        private readonly string _connectionString;
        private readonly String _patron;

        public StudentRepository(CustomConfigurationManager configManager)
        {
            _connectionString = configManager.connection;
            _patron = configManager.patron;
        }

        // Método para obtener todos los estudiantes
        public List<Estudiante> GetAllStudents()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SP_LeerEstudiante", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estudiantes.Add(new Estudiante
                        {
                            IdEstudiante = Convert.ToInt32(reader["IdEstudiante"]),
                            Carnet = reader["Carnet"].ToString(),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Dui = (byte[])reader["Dui"],
                            Direccion = reader["Direccion"].ToString(),
                            Email = (byte[])reader["Email"],
                            Telefono = (byte[])reader["Telefono"],
                            Estado = Convert.ToBoolean(reader["Estado"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        });
                    }
                }
            }

            return estudiantes;
        }

        // Método para buscar un estudiante por criterio específico
        public Estudiante SearchStudentByCriteria(string campoBusqueda, string valorBusqueda)
        {
            Estudiante estudiante = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SP_BuscarEstudiante", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Pasar los parámetros al procedimiento almacenado
                command.Parameters.AddWithValue("@CampoBusqueda", campoBusqueda);
                command.Parameters.AddWithValue("@ValorBusqueda", valorBusqueda);
                command.Parameters.AddWithValue("@Patron", _patron);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Asumimos que hay un solo resultado
                    {
                        estudiante = new Estudiante
                        {
                            IdEstudiante = Convert.ToInt32(reader["IdEstudiante"]),
                            Carnet = reader["Carnet"].ToString(),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Dui = (byte[])reader["Dui"],
                            Direccion = reader["Direccion"].ToString(),
                            Email = (byte[])reader["Email"],
                            Telefono = (byte[])reader["Telefono"],
                            Estado = Convert.ToBoolean(reader["Estado"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        };
                    }
                }
            }

            return estudiante;
        }
    }
}