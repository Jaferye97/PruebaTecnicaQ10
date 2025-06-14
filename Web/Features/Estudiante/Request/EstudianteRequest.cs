using System.ComponentModel.DataAnnotations;

namespace Web.Features.Estudiante.Request
{
    public class EstudianteRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El documento es requerido.")]
        [StringLength(20)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "El correo es requerido.")]
        [EmailAddress(ErrorMessage = "Ingrese, por favor, un correo válido.")]
        public string Correo { get; set; }

        public bool Activo { get; set; }
    }
}
