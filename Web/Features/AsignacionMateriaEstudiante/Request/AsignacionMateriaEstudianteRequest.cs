using System.ComponentModel.DataAnnotations;

namespace Web.Features.AsignacionMateriaEstudiante.Request
{
    public class AsignacionMateriaEstudianteRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El estudiante es requerido.")]
        [Display(Name = "Estudiante")]
        public int? EstudianteId { get; set; }

        [Required(ErrorMessage = "La materia es requerida.")]
        [Display(Name = "Materia")]
        public int? MateriaId { get; set; }

        [Required(ErrorMessage = "El semestre es requerido.")]
        [Display(Name = "Semestre")]
        public int? SemestreId { get; set; }
    }
}
