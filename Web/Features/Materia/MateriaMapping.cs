using Web.Features.Materia.Request;

namespace Web.Features.Materia
{
    public class MateriaMapping
    {
        public static MateriaRequest ToResquest(Domain.Model.Materia model)
        {
            return new MateriaRequest
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Codigo = model.Codigo,
                Creditos = model.Creditos,
                Activo = model.Activo
            };
        }

        public static Domain.Model.Materia ToModel(MateriaRequest request)
        {
            return new Domain.Model.Materia
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Codigo = request.Codigo,
                Creditos = (int)request.Creditos,
                Activo = request.Activo
            };
        }
    }
}
