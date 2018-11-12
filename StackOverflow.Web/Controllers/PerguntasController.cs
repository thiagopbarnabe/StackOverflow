using Microsoft.AspNetCore.Mvc;
using StackOverflow.Core.Entities;
using StackOverflow.Core.Services.Interfaces;

namespace StackOverflow.Web.Controllers
{
    public class PerguntasController : Controller
    {
        private readonly IPerguntasServices _perguntasServices;

        public PerguntasController(IPerguntasServices perguntasServices)
        {
            _perguntasServices = perguntasServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PerguntaId,Descricao,DataPublicacao,AutorId")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _perguntasServices.Incluir(pergunta);

                return RedirectToAction(nameof(Index));
            }
            return View(pergunta);
        }
    }
}