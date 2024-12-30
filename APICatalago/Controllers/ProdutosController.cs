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
            return Ok(_produtoRepository.GetProdutosPorCategoria(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _repository.Get(c => c.ProdutoId == id);

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

            _repository.Create(produto);

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

            _repository.Update(produto);
            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _repository.Get(p => p.ProdutoId == id);

            if (produto == null)
            {
                _logger.LogWarning($"Produto com id={id} não encontrado...");

            }

            _repository.Delete(produto);
            return Ok(produto);
        }
    }
}
