namespace APICatalogo.Repositories.PadraoUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        //Repositório especializado para a entidade Produto,
        //permitindo a implementação de métodos específicos além do CRUD básico.
        IProdutoRepository ProdutoRepository { get; }
        //Repositório especializado para a entidade Categoria, também permitindo métodos customizados.
        ICategoriaRepository CategoriaRepository { get; }
        //Chama SaveChanges no contexto para persistir todas as alterações feitas no banco de dados.
        void Commit();
    }
}
