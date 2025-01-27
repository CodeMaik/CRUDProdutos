using CRUDProdtuos.Data;
using CRUDProdtuos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDProdtuos.Controllers
{
    public class ProdutosController : Controller
    {

        readonly private ApplicationDbContext _db;


        public ProdutosController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ProdutoModel> produtos = _db.Produtos;

            return View(produtos);
        }
    }
}
