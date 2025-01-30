using CRUDProdtuos.Data;
using CRUDProdtuos.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDProdtuos.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {

        readonly private ApplicationDbContext _context;

        public ProdutoService(ApplicationDbContext context)
        {
                _context = context;
        }
        public async Task<ProdutoModel> CadastrarProduto(ProdutoModel produto)
        {
            try 
            {
              _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return produto;
            } catch (Exception ex)  
            {
            throw new Exception( ex.Message );
            
            }
        }

        public async Task<ProdutoModel> EditarProduto(ProdutoModel produto)
        {



            try 
            { 
            var produtoExistente = await _context.Produtos.FindAsync(produto.Id);
                if (produtoExistente == null) return null;

                produtoExistente.Nome = produto.Nome;
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.Preco = produto.Preco;
                produtoExistente.Quantidade = produto.Quantidade;


                _context.Produtos.Update(produtoExistente);
                await _context.SaveChangesAsync();
                return produtoExistente;
                
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirProduto(int id)
        {
            try 
            {
                var produto = await _context.Produtos.FindAsync(id);
                if (produto == null) return false;

                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProdutoModel>> ListarProduto()
        {
            return await _context.Produtos.ToListAsync();
        }
        public async Task<ProdutoModel> ListarProdutoPorId(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
