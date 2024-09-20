using System;
using System.Collections.Generic;
using dataLayer;
using entityLayer;

namespace businessLayer
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Método para obtener todos los estudiantes
        public List<Estudiante> GetAllStudents()
        {
            try
            {
                return _studentRepository.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener la lista de estudiantes.", ex);
            }
        }

        // Método para buscar un estudiante por un criterio específico
        public Estudiante SearchStudentByCriteria(string campoBusqueda, string valorBusqueda, string patron)
        {
            try
            {
                return _studentRepository.SearchStudentByCriteria(campoBusqueda, valorBusqueda);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al buscar un estudiante por criterio.", ex);
            }
        }
    }
}
