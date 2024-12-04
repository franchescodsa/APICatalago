using APICatalago.Context;
using APICatalago.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICatalago.Controllers
{
    [Route("[controller]")] //Rpta base para o controlador 
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        /*Significado: Armazena uma instância do AppDbContext, que é o contexto do banco de dados 
         * usado para interagir com o banco (Entity Framework Core).
Palavra-chave readonly: Garante que a variável só possa ser inicializada ou 
        atribuída dentro do construtor, aumentando a segurança e a imutabilidade.*/
        private readonly AppDbContext _context;
        /*
         Função: Injeta a dependência do contexto de banco de dados no controlador.
A injeção de dependência é feita automaticamente pelo framework 
        (caso o AppDbContext esteja registrado no contêiner de serviços no método Startup.
        ConfigureServices).
Objetivo: Permitir que o controlador acesse o banco de dados por meio do _context.*/
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        //Metodo action que vai retorna uma lista de produtos
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if(produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }
                return produtos;
        }
        //Metodo actions para retornar produto pelo ID 
        [HttpGet("{id:int}")]
       
        public ActionResult< Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p=> p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Íd não encontrado");
            }
            return produto;

        }
    }
}
