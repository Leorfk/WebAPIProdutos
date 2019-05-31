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
    public class JudiciaisController : Controller
    {
        static readonly IJudicialRepositorio repositorio = new JudicialRepositorio();

        [HttpGet]
        public IEnumerable<Judicial> GetTodos()
        {
            return repositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetJudicial")]
        public IActionResult GetByID(int id)
        {
            Judicial judicial = repositorio.Get(id);
            if (judicial == null)
            {
                return NotFound();
            }
            return new ObjectResult(judicial);
        }
        [HttpPost]
        public IActionResult AdicionarEmpresa([FromBody] Judicial judicial)
        {
            if (judicial == null)
            {
                return BadRequest(); 
            }
            judicial.DataDeposito = DateTime.Now;
            judicial = repositorio.Add(judicial);
            return CreatedAtRoute("GetJudicial", new { id = judicial.Id }, judicial);
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarEmpresa(int id, [FromBody] Judicial judicial)
        {
            if (judicial == null)
            {
                return BadRequest();
            }
            judicial.Id = id;
            if (!repositorio.Update(judicial))
            {
                return NotFound();
            }
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarRegistro(int id)
        {
            Judicial judicial = repositorio.Get(id);
            if (judicial == null)
            {
                return BadRequest();
            }
            repositorio.Remove(id);
            return new NoContentResult();
        }
    }
}
