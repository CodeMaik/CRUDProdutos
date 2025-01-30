using CRUDProdtuos.Data;
using CRUDProdtuos.Models;
using CRUDProdtuos.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace CRUDProdtuos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoInterface _produtoService;

        public ProdutosController(IProdutoInterface produtoService)
        {
            _produtoService = produtoService;
        }

        // Método para listar os produtos
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.ListarProduto();
            return View(produtos);
        }

        // Método para exibir a página de cadastro de produto
        public IActionResult Criar()
        {
            return View(new ProdutoModel());  // Passa um modelo vazio para a view
        }

        // Método para cadastrar o produto
        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.CadastrarProduto(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto); // Caso o modelo não seja válido, retorna para a view com o modelo preenchido
        }

        // Método para editar o produto
        public async Task<IActionResult> Editar(int id)
        {
            var produto = await _produtoService.ListarProdutoPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // Método para salvar a edição do produto
        [HttpPost]
        public async Task<IActionResult> Editar(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.EditarProduto(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto); // Caso o modelo não seja válido, retorna para a view com o modelo preenchido
        }

        // Método para excluir o produto
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _produtoService.ExcluirProduto(id);
            if (result)
                return RedirectToAction(nameof(Index));
            return NotFound();
        }
    }
}