
using APICatalago.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext context) : base(context)
    {
    }
    public PagedList<Categoria> GetCategorias(CategoriaParameters categoriaParameters)
    {
        var categorias = GetAll().OrderBy(p => p.CategoriaId).AsQueryable();

        var categoriasOrdenadas = PagedList<Categoria>.ToPagedList(categorias,
            categoriaParameters.PageNumber,
            categoriaParameters.PageSize);

        return categoriasOrdenadas;
    }
    public PagedList<Categoria> GetCategoriasFiltroNome(CategoriasFiltroNome categoriaParams)
    {
        var categorias = GetAll().AsQueryable();
        if (!string.IsNullOrEmpty(categoriaParams.Nome))
        {
            categorias = categorias.Where(p => p.Nome.Contains(categoriaParams.Nome));
        }
        var categoriasFiltradas = PagedList<Categoria>.ToPagedList(categorias,
            categoriaParams.PageNumber,
            categoriaParams.PageSize);

        return categoriasFiltradas;
    }


}
