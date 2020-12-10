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
    public class LivroBusiness : ILivroBusiness
    {
        private readonly IRepository<Livro> _repository;
        private readonly LivroParser _parser;

        public LivroBusiness(IRepository<Livro> repository)
        {
            _repository = repository;
            _parser     = new LivroParser();
        }

        public async Task<bool> Salvar(LivroDTO source)
        {
            var livro   = _parser.Parse(source);
            var sucesso = await _repository.Salvar(livro);

            if (sucesso)
            {
                source.Id = livro.Id;
            }

            return sucesso;
        }        

        public Task<bool> Atualizar(LivroDTO source)
        {
            var livro = _parser.Parse(source);
            return _repository.Atualizar(livro);
        }

        public async ValueTask<LivroDTO> BuscarPorId(int id)
        {
            var livro = await _repository.BuscarPorId(id);
            return _parser.Parse(livro);
        }

        public async Task<IEnumerable<LivroDTO>> BuscarTodos()
        {
            var livros = await _repository.BuscarTodos();
            return _parser.Parse(livros);
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