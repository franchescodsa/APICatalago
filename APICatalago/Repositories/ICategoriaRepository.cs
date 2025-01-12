﻿using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public interface ICategoriaRepository : IRepository<Categoria>
{
    PagedList<Categoria> GetCategorias(CategoriaParameters categoriaParameters);
    PagedList<Categoria> GetCategoriasFiltroNome(CategoriasFiltroNome categoriaParams);
}
