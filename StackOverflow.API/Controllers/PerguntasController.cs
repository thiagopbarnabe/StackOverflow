using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StackOverflow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntasController : ControllerBase
    {
        public IActionResult ConsultarPergunta()
        {
            return Ok();
        }

        public IActionResult CriarPergunta()
        {
            return Ok();
        }

        public IActionResult AlterarPergunta()
        {
            return Ok();
        }

        public IActionResult DeletarPergunta()
        {
            return Ok();
        }
    }
}