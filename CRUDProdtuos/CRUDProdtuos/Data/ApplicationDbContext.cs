using CRUDProdtuos.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDProdtuos.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<ProdutoModel> Produtos { get; set; }

    }
}
