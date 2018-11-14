using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackOverflow.Core.Contexts;
using StackOverflow.Core.Entities;

namespace StackOverflow.Web.Controllers
{
    public class RespostasController : Controller
    {
        private readonly StackOverflowContext _context;

        public RespostasController(StackOverflowContext context)
        {
            _context = context;
        }

        // GET: Respostas
        public async Task<IActionResult> Index()
        {
            var stackOverflowContext = _context.Respostas.Include(r => r.Autor).Include(r => r.Categoria).Include(r => r.Pergunta);
            return View(await stackOverflowContext.ToListAsync());
        }

        // GET: Respostas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas
                .Include(r => r.Autor)
                .Include(r => r.Categoria)
                .Include(r => r.Pergunta)
                .FirstOrDefaultAsync(m => m.RespostaId == id);
            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // GET: Respostas/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Login");
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Descricao");
            ViewData["PerguntaId"] = new SelectList(_context.Perguntas, "PerguntaId", "Descricao");
            return View();
        }

        // POST: Respostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RespostaId,Descricao,DataPublicacao,AutorId,PerguntaId,CategoriaId")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resposta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Login", resposta.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Descricao", resposta.CategoriaId);
            ViewData["PerguntaId"] = new SelectList(_context.Perguntas, "PerguntaId", "Descricao", resposta.PerguntaId);
            return View(resposta);
        }

        // GET: Respostas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas.FindAsync(id);
            if (resposta == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Login", resposta.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Descricao", resposta.CategoriaId);
            ViewData["PerguntaId"] = new SelectList(_context.Perguntas, "PerguntaId", "Descricao", resposta.PerguntaId);
            return View(resposta);
        }

        // POST: Respostas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RespostaId,Descricao,DataPublicacao,AutorId,PerguntaId,CategoriaId")] Resposta resposta)
        {
            if (id != resposta.RespostaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resposta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespostaExists(resposta.RespostaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Login", resposta.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Descricao", resposta.CategoriaId);
            ViewData["PerguntaId"] = new SelectList(_context.Perguntas, "PerguntaId", "Descricao", resposta.PerguntaId);
            return View(resposta);
        }

        // GET: Respostas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas
                .Include(r => r.Autor)
                .Include(r => r.Categoria)
                .Include(r => r.Pergunta)
                .FirstOrDefaultAsync(m => m.RespostaId == id);
            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Respostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resposta = await _context.Respostas.FindAsync(id);
            _context.Respostas.Remove(resposta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespostaExists(int id)
        {
            return _context.Respostas.Any(e => e.RespostaId == id);
        }
    }
}
