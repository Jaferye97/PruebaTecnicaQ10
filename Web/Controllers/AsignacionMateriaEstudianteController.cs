using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Interface.Services;
using Web.Features.AsignacionMateriaEstudiante;
using Web.Features.AsignacionMateriaEstudiante.Request;

namespace Web.Controllers
{
    public class AsignacionMateriaEstudianteController : Controller
    {
        private readonly ILogger<EstudianteController> _logger;
        private readonly IEstudianteService _estudianteService;
        private readonly IMateriaService _materiaService;
        private readonly ISemestreService _semestreService;
        private readonly IMateriaEstudianteSemestreService _materiaEstudianteSemestreService;

        public AsignacionMateriaEstudianteController(ILogger<EstudianteController> logger,
                                                     IEstudianteService estudianteService,
                                                     IMateriaService materiaService,
                                                     ISemestreService semestreService,
                                                     IMateriaEstudianteSemestreService materiaEstudianteSemestreService)
        {
            _logger = logger;
            _estudianteService = estudianteService;
            _materiaService = materiaService;
            _semestreService = semestreService;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet(Name = "ObtenerDatosCombos")]
        public async Task<IActionResult> ObtenerDatosCombosAsync()
        {
            var estudiantes = await _estudianteService.GetAllActivos();
            var materias = await _materiaService.GetAllActivos();
            var semestre = await _semestreService.GetAllActivos();

            var model = new
            {
                Estudiantes = estudiantes
                        .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = $"{e.Documento} - {e.Nombre}" })
                        .ToList(),

                Materias = materias
                        .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = $"({m.Codigo}) {m.Nombre}" })
                        .ToList(),

                Semestres = semestre
                        .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = $"{s.Mes}/{s.Anio}" })
                        .ToList()
            };

            return Json(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AsignacionMateriaEstudianteRequest request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Mensaje = "Ocurrió un error de validación.";
                return View("Create", request);
            }

            var yaExiste = await _materiaEstudianteSemestreService.ValidarExisteAsignacionAsync(
                                    request.EstudianteId.Value,
                                    request.MateriaId.Value,
                                    request.SemestreId.Value);

            if (yaExiste)
            {
                ViewBag.Mensaje = "El estudiante ya tiene asignada la materia para el semestre.";
                return View("Create", request);
            }

            var validacionCreditos = await _materiaEstudianteSemestreService.ValidarLimiteCreditosPorMateriaAsync(
                                    request.EstudianteId.Value,
                                    request.SemestreId.Value);

            if (validacionCreditos)
            {
                ViewBag.Mensaje = "El estudiante ya tiene 3 materias asignadas de mpas de 4 créditos para el semestre seleccionado.";
                return View("Create", request);
            }

            await _materiaEstudianteSemestreService.AddAsync(AsignacionMateriaEstudianteMapping.ToModel(request));
            return RedirectToAction("Index");
        }
    }
}
