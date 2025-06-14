using Microsoft.AspNetCore.Mvc;
using Service.Interface.Services;

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
    }
}
