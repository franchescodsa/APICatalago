using APICatalago.Context;
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

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
    }
}
