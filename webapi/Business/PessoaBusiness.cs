using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Business.Interfaces;
using webapi.Data.Interfaces;
using webapi.DTO;
using webapi.DTO.Parser;
using webapi.Models;

namespace webapi.Business
{
    /// <summary>
    /// Lógica de negócio vai aqui
    /// </summary>
    public class PessoaBusiness : IPessoaBusiness
    {
        private readonly IPessoaRepository _repository;
        private readonly PessoaParser _parser;

        public PessoaBusiness(IPessoaRepository repository)
        {
            _repository = repository;
            _parser     = new PessoaParser();
        }

        public async Task<bool> Salvar(PessoaDTO source)
        {
            var pessoa = _parser.Parse(source);
            var sucesso = await _repository.Salvar(pessoa);

            if (sucesso)
            {
                source.Id = pessoa.Id;
            }
            return sucesso;
        }

        public Task<bool> Atualizar(PessoaDTO source)
        {
            var pessoa = _parser.Parse(source);
            return _repository.Atualizar(pessoa);
        }

        public async ValueTask<PessoaDTO> BuscarPorId(int id)
        {
            var pessoa = await _repository.BuscarPorId(id);
            return _parser.Parse(pessoa);
        }

        public async Task<IEnumerable<PessoaDTO>> BuscarTodos()
        {
            var pessoas = await _repository.BuscarTodos();
            return _parser.Parse(pessoas);
        }

        public async Task<IEnumerable<PessoaDTO>> BuscarPorNome(string nome)
        {
            var pessoas = await _repository.BuscarPorNome(nome);
            return _parser.Parse(pessoas);
        }

        public Task<bool> Excluir(int id)
        {
            return _repository.Excluir(id);
        }

        public Task<bool> RegistroExiste(int id)
        {
            return _repository.RegistroExiste(id);
        }
    }
}