using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Business.Interfaces;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroBusiness _business;

        public LivrosController(ILivroBusiness business)
        {
            _business = business;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var livros = await _business.BuscarTodos();
            
            return Ok(livros);
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var livro = await _business.BuscarPorId(id);
            
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post(Livro livro)
        {
            var sucesso = await _business.Salvar(livro);
            
            if (sucesso)
            {
                return Ok(livro);
            }
            return BadRequest();            
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> Put(Livro livro)
        {
            if (livro == null)
            {
                return BadRequest();
            }

            var existe = await _business.RegistroExiste(livro.Id);

            if (!existe)
            {
                return NotFound();
            }

            var sucesso = await _business.Atualizar(livro);

            if (sucesso)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = await _business.RegistroExiste(id);

            if (!existe)
            {
                return NotFound();
            }

            var sucesso = await _business.Excluir(id);

            if (sucesso)
            {
                return NoContent();
            }        
            return BadRequest();               
        }        

    }
}