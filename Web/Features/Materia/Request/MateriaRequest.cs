using System.ComponentModel.DataAnnotations;

namespace Web.Features.Materia.Request
{
    public class MateriaRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El codigo es requerido.")]
        [StringLength(20)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Los créditos son requeridos.")]
        [Range(1, int.MaxValue, ErrorMessage = "Los créditos deben ser mayores a 0.")]
        public int? Creditos { get; set; }

        public bool Activo { get; set; }
    }
}
