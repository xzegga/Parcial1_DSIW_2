using System.ComponentModel.DataAnnotations;

namespace publicLayer.Models
{
    public class LoginViewModel
    {
        //[Required(ErrorMessage = "Primer nombre es requerido")]
        //[Display(Name = "Nombre")]
        //public string FirstName { get; set; }

        //[Required(ErrorMessage = "El Apellido es requerido")]
        //[Display(Name = "Apellido")]
        //public string LastName { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [Display(Name = "Nombre de usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}