using Microsoft.AspNetCore.Mvc;
using Service.Interface.Services;
using Web.Features.Estudiante;
using Web.Features.Estudiante.Request;

namespace Web.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly ILogger<EstudianteController> _logger;
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService, ILogger<EstudianteController> logger)
        {
            _estudianteService = estudianteService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var estudiantes = await _estudianteService.GetAllAsync();
            return View(estudiantes);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleActivo(int id)
        {
            await _estudianteService.ToggleActivoAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var estudiante = await _estudianteService.GetAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(EstudianteMapping.ToResquest(estudiante));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EstudianteRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var model = EstudianteMapping.ToModel(request);

            if (await _estudianteService.ExisteDocumentoAsync(request.Documento, request.Id))
            {
                ModelState.AddModelError("Documento", "Ya existe un estudiante diferente con ese documento.");
                return View(request);
            }

            await _estudianteService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstudianteRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            if(await _estudianteService.ExisteDocumentoAsync(request.Documento))
            {
                ModelState.AddModelError("Documento", "Ya existe un estudiante con ese documento.");
                return View(request);
            }

            await _estudianteService.AddAsync(EstudianteMapping.ToModel(request));
            return RedirectToAction(nameof(Index));
        }
    }
}
