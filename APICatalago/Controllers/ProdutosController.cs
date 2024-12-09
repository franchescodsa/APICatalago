using APICatalago.Context;
using APICatalago.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
            if(produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }
                return produtos;
        }
        //Metodo actions para retornar produto pelo ID 
        [HttpGet("{id:int:min(1)}", Name="ObterProduto")] // passar um Id maio ou igual a 1
       
        public async Task<ActionResult<Produto>> Get([FromQuery]int id)
        {
            
            var produto = await _context.Produtos.AsNoTracking()
                .FirstOrDefaultAsync(p=> p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Íd não encontrado");
            }
            return produto;

        }
        //Método action para cadastrar POST
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            
                return BadRequest();

                _context.Produtos.Add(produto);
                _context.SaveChanges();

                // 201 created e aciona a rota ObterProduto
                return new CreatedAtRouteResult("ObterProduto", new
                {
                    id = produto.ProdutoId
                }, produto);
            

        }
        //Metodo para atualizar\editar produto
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto) { 
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            //localizar produtopor id
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto is null)
            {
                return NotFound("Produto não encontrado");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);

        }

        
    }
}
