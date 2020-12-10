using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Business.Interfaces;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaBusiness _business;

        public PessoasController(IPessoaBusiness business)
        {
            _business = business;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pessoas = await _business.BuscarTodos();
            
            return Ok(pessoas);
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var pessoa = await _business.BuscarPorId(id);
            
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post(Pessoa pessoa)
        {
            var sucesso = await _business.Salvar(pessoa);
            
            if (sucesso)
            {
                return Ok(pessoa);
            }
            return BadRequest();            
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> Put(Pessoa pessoa)
        {
            var sucesso = await _business.Atualizar(pessoa);

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
            var sucesso = await _business.Excluir(id);

            if (sucesso)
            {
                return NoContent();
            }        
            return BadRequest();            
        }        

    }
}