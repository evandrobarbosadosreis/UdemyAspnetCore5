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
        private readonly IPessoaRepository _repo;

        public PessoaBusiness(IPessoaRepository repository)
        {
            _repo = repository;
        }

        public Task<bool> Atualizar(Pessoa pessoa)
        {
            return _repo.Atualizar(pessoa);
        }

        public Task<Pessoa> BuscarPorId(int id)
        {
            return _repo.BuscarPorId(id);
        }

        public Task<IEnumerable<Pessoa>> BuscarTodos()
        {
            return _repo.BuscarTodos();
        }

        public Task<bool> Excluir(int id)
        {
            return _repo.Excluir(id);
        }

        public Task<bool> Salvar(Pessoa pessoa)
        {
            return _repo.Salvar(pessoa);
        }
    }
}