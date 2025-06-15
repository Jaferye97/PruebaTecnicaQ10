using Web.Features.AsignacionMateriaEstudiante.Request;

namespace Web.Features.AsignacionMateriaEstudiante
{
    public class AsignacionMateriaEstudianteMapping
    {
        public static Domain.Model.MateriaEstudianteSemestre ToModel(AsignacionMateriaEstudianteRequest request)
        {
            return new Domain.Model.MateriaEstudianteSemestre
            {
                Id = request.Id,
                EstudianteId = request.EstudianteId.Value,
                SemestreId = request.SemestreId.Value,
                MateriaId = request.MateriaId.Value,
            };
        }
    }
}
