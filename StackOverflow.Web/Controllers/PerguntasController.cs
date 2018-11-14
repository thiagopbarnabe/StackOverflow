using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackOverflow.Core.Contexts;
using StackOverflow.Core.Entities;

namespace StackOverflow.Web.Controllers
{
    [Authorize]
    public class PerguntasController : Controller
    {
        private readonly StackOverflowContext _context;

        public PerguntasController(StackOverflowContext context)
        {
            _context = context;
        }

        // GET: Perguntas
        public async Task<IActionResult> Index()
        {   
            var stackOverflowContext = _context.Perguntas.Include(p => p.Autor).Include(p => p.Categoria);
            return View(await stackOverflowContext.ToListAsync());
        }

        // GET: Perguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas
                .Include(p => p.Autor)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.PerguntaId == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }

        // GET: Perguntas/Create
        public IActionResult Create()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            ViewData["AutorId"] = new SelectList(_context.Autores.Where(x=>x.AutorId == int.Parse(userId)), "AutorId", "Login", userId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Descricao");
            return View();
        }

        // POST: Perguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerguntaId,Titulo,Descricao,DataPublicacao,AutorId,CategoriaId")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pergunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Login", pergunta.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Descricao", pergunta.CategoriaId);
            return View(pergunta);
        }

        // GET: Perguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas.FindAsync(id);
            if (pergunta == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Login", pergunta.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Descricao", pergunta.CategoriaId);
            return View(pergunta);
        }

        // POST: Perguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerguntaId,Titulo,Descricao,DataPublicacao,AutorId,CategoriaId")] Pergunta pergunta)
        {
            if (id != pergunta.PerguntaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pergunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerguntaExists(pergunta.PerguntaId))
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
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Login", pergunta.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Descricao", pergunta.CategoriaId);
            return View(pergunta);
        }

        // GET: Perguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas
                .Include(p => p.Autor)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.PerguntaId == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }

        // POST: Perguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pergunta = await _context.Perguntas.FindAsync(id);
            _context.Perguntas.Remove(pergunta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerguntaExists(int id)
        {
            return _context.Perguntas.Any(e => e.PerguntaId == id);
        }
    }
}
