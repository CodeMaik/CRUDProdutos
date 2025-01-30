using CRUDProdtuos.Models;

namespace CRUDProdtuos.Services.Produto
{
    public interface IProdutoInterface
    {

        Task<ProdutoModel> ListarProdutoPorId(int id);
        Task<List<ProdutoModel>> ListarProduto();
        Task<ProdutoModel> CadastrarProduto(ProdutoModel produto);
        Task<ProdutoModel> EditarProduto(ProdutoModel produto);
        Task<bool> ExcluirProduto(int id);

    }
}
