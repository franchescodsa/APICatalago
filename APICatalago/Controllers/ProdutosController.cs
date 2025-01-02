using APICatalogo.Models;
using APICatalogo.Repositories.PadraoUnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger<ProdutosController> _logger;


        public ProdutosController(ILogger<ProdutosController> logger, IUnitOfWork uof)
        {

            _logger = logger;
            _uof = uof;
        }
        [HttpGet("produtos/{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPorCategoria(int id)
        {
            return Ok(_uof.ProdutoRepository.GetProdutosPorCategoria(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return Ok(_uof.ProdutoRepository.GetAll());
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _uof.ProdutoRepository.Get(c => c.ProdutoId == id);

            if (produto == null)
            {
                _logger.LogWarning($"Produto com id= {id} não encontrado...");
                return NotFound($"Produto com id= {id} não encontrado...");
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _uof.ProdutoRepository.Create(produto);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();
            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _uof.ProdutoRepository.Get(p => p.ProdutoId == id);

            if (produto == null)
            {
                _logger.LogWarning($"Produto com id={id} não encontrado...");

            }

            _uof.ProdutoRepository.Delete(produto);
            _uof.Commit();
            return Ok(produto);
        }
    }
}
