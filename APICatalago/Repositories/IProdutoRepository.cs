using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutosPorCategoria(int id);
    PagedList<Produto> GetProdutosFiltroPreco(ProdutosFiltroPreco produtosFiltroParams);
    PagedList<Produto> GetProdutos(ProdutosParameters produtosParams);



}
