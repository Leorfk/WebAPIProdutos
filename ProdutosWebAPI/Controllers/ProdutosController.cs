using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdutosWebAPI.Interfaces;
using ProdutosWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProdutosWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        static readonly IProdutoRepositorio repositorio = new ProdutoRepositorio();

        [HttpGet]
        public IEnumerable<Produto> GetTodos()
        {
            return repositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public IActionResult GetProdutoPorId(int id)
        {
            Produto produto = repositorio.Get(id);
            if (produto == null)
            {
                return NotFound();
            }
            return new ObjectResult(produto);
        }
        [HttpPost]
        public IActionResult CriarProduto([FromBody] Produto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            model = repositorio.Add(model);
            return CreatedAtRoute("GetProduto", new { id = model.Id}, model);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, [FromBody] Produto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            model.Id = id;
            if (!repositorio.Update(model))
            {
                return NotFound();
            }
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            Produto model = repositorio.Get(id);
            if (model == null)
            {
                return BadRequest();
            }
            repositorio.Remove(id);
            return new NoContentResult();
        }
    }
}
