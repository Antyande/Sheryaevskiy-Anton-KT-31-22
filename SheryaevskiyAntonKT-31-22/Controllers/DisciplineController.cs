using Microsoft.AspNetCore.Mvc;
using SheryaevskiyAntonKT_31_22.Filters;
using SheryaevskiyAntonKT_31_22.Interfaces;

namespace SheryaevskiyAntonKT_31_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        private readonly ILogger<DisciplineController> _logger;
        private readonly IDisciplineService _disciplineService;
        private DisciplineService service;

        public DisciplineController(ILogger<DisciplineController> logger, IDisciplineService disciplineService)
        {
            _logger = logger;
            _disciplineService = disciplineService;
        }


        [HttpPost(Name = "GetDisciplinesByFilter")]
        public async Task<IActionResult> GetDisciplinesByFilterAsync([FromQuery] DisciplineFilter filter, CancellationToken cancellationToken = default)
        {
            var disciplines = await _disciplineService.GetDisciplinesByFilterAsync(filter, cancellationToken);

            if (disciplines == null || disciplines.Length == 0)
            {
                return NotFound();
            }

            return Ok(disciplines);
        }

        [HttpGet("error")]
        public IActionResult TriggerError()
        {
            throw new Exception("Это тестовое исключение для проверки middleware");
        }
    }
}
