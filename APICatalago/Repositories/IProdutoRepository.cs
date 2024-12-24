using APICatalago.Models;
using APICatalogo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalago.Repositories
{
    public interface IProdutoRepository
    {
        Task<IQueryable<Produto>> GetAllAsync();
        Task<Produto?> GetByIdAsync(int id);
        Task AddAsync(Produto produto);
        Task bool UpdateAsync(Produto produto);
        Task bool DeleteAsync(int id);
    }
}
