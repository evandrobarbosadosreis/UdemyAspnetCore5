using System;
using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            var pessoas = _service.BuscarTodos();
            return Ok(pessoas);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var pessoa = _service.BuscarPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return Ok(_service.Salvar(pessoa));
        }

        [Route("")]
        [HttpPut]
        public IActionResult Put(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return Ok(_service.Atualizar(pessoa));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pessoa = _service.BuscarPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            _service.Excluir(pessoa);
            return NoContent();
        }        

    }
}