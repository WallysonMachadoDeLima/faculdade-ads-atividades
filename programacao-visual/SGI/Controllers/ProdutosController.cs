using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGI.Data;
using SGI.Models;

namespace SGI.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // RF01 — Listar Produtos (substitui: SELECT ... FROM produtos ORDER BY nome ASC)
        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produtos
                .OrderBy(p => p.Nome)
                .ToListAsync();

            return View(produtos);
        }

        // RF05 — Detalhes do Produto (substitui: SELECT * FROM produtos WHERE id = @id)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // RF02 — Formulário de Cadastro
        public IActionResult Create()
        {
            return View();
        }

        // RF02 — Cadastrar Produto (substitui: INSERT INTO produtos ...)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Preco,Quantidade")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // RF03 — Formulário de Edição (substitui: SELECT * FROM produtos WHERE id = @id)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // RF03 — Atualizar Produto (substitui: UPDATE produtos SET ... WHERE id = @id)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,Quantidade")] Produto produto)
        {
            if (id != produto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // RF04 — Confirmação de Exclusão (substitui: SELECT * FROM produtos WHERE id = @id)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // RF04 — Excluir Produto (substitui: DELETE FROM produtos WHERE id = @id)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(p => p.Id == id);
        }
    }
}
