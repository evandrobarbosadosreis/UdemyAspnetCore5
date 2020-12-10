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
    public class LivroBusiness : ILivroBusiness
    {
        private readonly IRepository<Livro> _repository;

        public LivroBusiness(IRepository<Livro> repository)
        {
            _repository = repository;
        }

        public Task<bool> Atualizar(Livro livro)
        {
            return _repository.Atualizar(livro);
        }

        public ValueTask<Livro> BuscarPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }

        public Task<List<Livro>> BuscarTodos()
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

        public Task<bool> Salvar(Livro livro)
        {
            return _repository.Salvar(livro);
        }
    }
}