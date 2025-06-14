using Microsoft.AspNetCore.Mvc;
using Service.Interface.Services;

namespace Web.Controllers
{
    public class AsignacionMateriaEstudianteController : Controller
    {
        private readonly ILogger<EstudianteController> _logger;
        private readonly IEstudianteService _estudianteService;
        private readonly IMateriaEstudianteSemestreService _materiaEstudianteSemestreService;

        public AsignacionMateriaEstudianteController(ILogger<EstudianteController> logger, IEstudianteService estudianteService, IMateriaEstudianteSemestreService materiaEstudianteSemestreService)
        {
            _logger = logger;
            _estudianteService = estudianteService;
            _materiaEstudianteSemestreService = materiaEstudianteSemestreService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(Name = "BuscarEstudiantes")]
        public async Task<IActionResult> BuscarEstudiantesAsync(string filtro)
        {
            var estudiantes = await _estudianteService.GetByNombreDocumentoByFilter(filtro);
            var result = estudiantes.Select(e => new
            {
                id = e.Id,
                nombre = e.Nombre,
                documento = e.Documento
            });

            return Json(result);
        }

        [HttpGet(Name = "BuscarHistorial")]
        public async Task<IActionResult> BuscarHistorialAsync(int estudianteId)
        {
            var estudiantes = await _materiaEstudianteSemestreService.GetHistorialEstudianteByEstudianteId(estudianteId);
            var result = estudiantes.Select(e => new
            {
                id = e.Id,
                nombreMateria = e.Materia.Nombre,
                codigoMateria = e.Materia.Codigo,
                creditosMateria = e.Materia.Creditos,
                mesSemestre = e.Semestre.Mes,
                anioSemestre = e.Semestre.Anio,
            });

            return Json(result);
        }
    }
}
