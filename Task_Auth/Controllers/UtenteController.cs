using Microsoft.AspNetCore.Mvc;
using Task_Auth.Services;

namespace Task_Auth.Controllers
{
    [Route("utente")]
    [ApiController]
    public class UtenteController : Controller
    {
        private readonly UtenteService _service;
        public UtenteController(UtenteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
    }
}
