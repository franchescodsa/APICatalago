using APICatalago.Context;

namespace APICatalogo.Repositories.PadraoUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _context;


        public IProdutoRepository _produtoRepo;

        public ICategoriaRepository _categoriaRepo;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;


        }

        public void Dispose()
        {
            _context.Dispose();
        }
        /*Verifica se _produtoRepo já foi instanciado:
Se sim, retorna a instância existente.
Se não, cria uma nova instância de ProdutoRepository usando o contexto _context*/
        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
            }
        }
        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
