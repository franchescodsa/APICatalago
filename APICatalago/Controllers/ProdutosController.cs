
using APICatalago.Repositories;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repository;
        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(IProdutoRepository repository, ILogger<ProdutosController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _repository.GetByIdAsync(id);

            if (produto == null)
            {
                _logger.LogWarning($"Produto com id= {id} não encontrado...");
                return NotFound($"Produto com id= {id} não encontrado...");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Produto produto)
        {
            if (produto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            await _repository.AddAsync(produto);

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var updateResult = await Task.Run(() => _repository.UpdateAsync(produto));
            if (!updateResult)
            {
                _logger.LogWarning($"Erro ao atualizar o produto com id={id}.");
                return StatusCode(500, "Erro ao atualizar o produto.");
            }

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var produto = await _repository.GetByIdAsync(id);

            if (produto == null)
            {
                _logger.LogWarning($"Produto com id={id} não encontrado...");
                return NotFound($"Produto com id={id} não encontrado...");
            }

            var deleteResult = await Task.Run(() => _repository.DeleteAsync(id));
            if (!deleteResult)
            {
                _logger.LogWarning($"Erro ao deletar o produto com id={id}.");
                return StatusCode(500, "Erro ao deletar o produto.");
            }

            return Ok(produto);
        }
    }
}
