using Microsoft.EntityFrameworkCore;

namespace LivrariaAPI.Models
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext(DbContextOptions<ProdutosContext> options)
            : base (options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
