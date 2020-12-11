using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Business.Interfaces;
using webapi.DTO;

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

        [Route("{paginaAtual:Min(1)}/{itensPagina:Min(5)}")]
        [HttpGet]
        public async Task<IActionResult> Get(int paginaAtual, int itensPagina, [FromQuery] string nome)
        {
            var pessoas = await _business.BuscarTodos(
                nome, 
                paginaAtual, 
                itensPagina);
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
        public async Task<IActionResult> Post(PessoaDTO pessoa)
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
        public async Task<IActionResult> Put(PessoaDTO pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }

            var existe = await _business.RegistroExiste(pessoa.Id);

            if (!existe)
            {
                return NotFound();
            }

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