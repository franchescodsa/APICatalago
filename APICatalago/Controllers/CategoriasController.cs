﻿using APICatalago.Context;
using APICatalago.Models;
using APICatalogo.Filters;
using APICatalogo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }
        //private readonly IMeuServico _meuServico;

        [HttpGet("produtos")]
        //retornar categoria com produto
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            
            try
            {
               return _context.Categorias.Include(p=>p.Produtos).AsNoTracking().ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação");
            }
        }
        // retornar todas categorias
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                
                return _context.Categorias.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                //tratar erro 500
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorre um problema ao tratar a sua solicitação");
            }
           
        }
        // retornar categoria pelo ID
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {

            //throw new Exception("EXCEÇÃO AO RETORNAR A CATEGORIA PLEO ID");
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

                if (categoria == null)
                {
                    return NotFound("Categoria não encontrada...");
                }
                return Ok(categoria);
            }
            catch (Exception)
            {

                //tratar erro 500
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorre um problema ao tratar a sua solicitação");
            }
           
        }
        //criar uma categoria
        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest();

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }
        //atualizar/editar uma categoria
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound($"Categoria com id={id}não encontrada...");
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }
    }
}
