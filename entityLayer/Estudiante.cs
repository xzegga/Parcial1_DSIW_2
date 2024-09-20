using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entityLayer
{
    public class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstudiante { get; set; }

        [Required]
        [StringLength(20)]
        public string Carnet { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(256)]
        public byte[] Dui { get; set; } 

        [Required]
        [StringLength(255)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(256)]
        public byte[] Email { get; set; }  

        [Required]
        [MaxLength(256)]
        public byte[] Telefono { get; set; }  

        [Required]
        public bool Estado { get; set; } 

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Fecha { get; set; }  // Fecha autogenerada
    }
}
