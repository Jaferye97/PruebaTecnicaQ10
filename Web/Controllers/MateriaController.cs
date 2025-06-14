using Microsoft.AspNetCore.Mvc;
using Service.Interface.Services;
using Web.Features.Materia;
using Web.Features.Materia.Request;

namespace Web.Controllers
{
    public class MateriaController : Controller
    {
        private readonly ILogger<MateriaController> _logger;
        private readonly IMateriaService _materiaService;

        public MateriaController(ILogger<MateriaController> logger, IMateriaService materiaService)
        {
            _logger = logger;
            _materiaService = materiaService;
        }


        public async Task<IActionResult> Index()
        {
            var materias = await _materiaService.GetAllAsync();
            return View(materias);

        }

        [HttpPost]
        public async Task<IActionResult> ToggleActivo(int id)
        {
            await _materiaService.ToggleActivoAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var materia = await _materiaService.GetAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(MateriaMapping.ToResquest(materia));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MateriaRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            var model = MateriaMapping.ToModel(request);

            if (await _materiaService.ExisteCodigoAsync(request.Codigo, request.Id))
            {
                ModelState.AddModelError("Codigo", "Ya existe una materia diferente con ese codigo.");
                return View(request);
            }

            await _materiaService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MateriaRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            if (await _materiaService.ExisteCodigoAsync(request.Codigo))
            {
                ModelState.AddModelError("Documento", "Ya existe una materia con ese codigo.");
                return View(request);
            }

            await _materiaService.AddAsync(MateriaMapping.ToModel(request));
            return RedirectToAction(nameof(Index));
        }
    }
}
