using APICatalogo.Models;
using APICatalogo.Repositories;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IRepository<Categoria> _repository;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(IRepository<Categoria> repository, ILogger<CategoriasController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null)
            {
                _logger.LogWarning($"Categoria com id= {id} não encontrada...");
                return NotFound($"Categoria com id= {id} não encontrada...");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Categoria categoria)
        {
            if (categoria is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            await _repository.AddAsync(categoria);

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            await _repository.UpdateAsync(categoria);
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null)
            {
                _logger.LogWarning($"Categoria com id={id} não encontrada...");
                return NotFound($"Categoria com id={id} não encontrada...");
            }

            await _repository.DeleteAsync(id);
            return Ok(categoria);
        }
    }
}
