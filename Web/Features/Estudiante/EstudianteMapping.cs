using Web.Features.Estudiante.Request;

namespace Web.Features.Estudiante
{
    public class EstudianteMapping
    {
        public static EstudianteRequest ToResquest(Domain.Model.Estudiante model)
        {
            return new EstudianteRequest
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Documento = model.Documento,
                Correo = model.Correo,
                Activo = model.Activo
            };
        }

        public static Domain.Model.Estudiante ToModel(EstudianteRequest request)
        {
            return new Domain.Model.Estudiante
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Documento = request.Documento,
                Correo = request.Correo,
                Activo = request.Activo
            };
        }
    }
}
