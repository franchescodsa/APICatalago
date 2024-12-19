using APICatalago.Models;

namespace APICatalago.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategoriasAsyc();
        Task<Categoria?> GetIdAsync(int id);
        Task CreateAsync(Categoria categoria);
        Task UpdateAsync(Categoria categoria);
        Task DeleteAsync(int id);
    }
}
