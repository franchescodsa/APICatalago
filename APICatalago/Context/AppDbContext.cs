using APICatalago.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Context
{
    // realizar a comunucação entre as  entidades eo banco de dados

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
