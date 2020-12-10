using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Business.Interfaces;
using webapi.Data.Interfaces;
using webapi.Models;

namespace webapi.Business
{
    /// <summary>
    /// Lógica de negócio vai aqui
    /// </summary>
    public class PessoaBusiness : IPessoaBusiness
    {
        private readonly IPessoaRepository _repository;

        public PessoaBusiness(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Atualizar(Pessoa pessoa)
        {
            return _repository.Atualizar(pessoa);
        }

        public ValueTask<Pessoa> BuscarPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }

        public Task<List<Pessoa>> BuscarTodos()
        {
            return _repository.BuscarTodos();
        }

        public Task<bool> Excluir(int id)
        {
            return _repository.Excluir(id);
        }

        public Task<bool> RegistroExiste(int id)
        {
            return _repository.RegistroExiste(id);
        }

        public Task<bool> Salvar(Pessoa pessoa)
        {
            return _repository.Salvar(pessoa);
        }
    }
}