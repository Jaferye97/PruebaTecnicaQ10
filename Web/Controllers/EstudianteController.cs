using Microsoft.AspNetCore.Mvc;
using Service.Interface.Services;

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
    }
}
