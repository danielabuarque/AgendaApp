using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.ApiTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        [HttpPost("criar")]
        public IActionResult Criar()
        {
            return Ok();
        }

        [HttpPut("alterar/{id}")]
        public IActionResult Alterar(Guid id)
        {
            return Ok();
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Excluir(Guid id)
        {
            return Ok();
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok();
        }

        [HttpGet("obter/{id}")]
        public IActionResult Obter(Guid id)
        {
            return Ok();
        }
    }
}
