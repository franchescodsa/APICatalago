using APICatalago.Context;
using APICatalago.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria?> GetIdAsync(int id)
        {
            return await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(p => p.CategoriaId == id);
        }

        public async Task CreateAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
