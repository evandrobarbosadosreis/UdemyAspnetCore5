using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        private Expression<Func<Livro, bool>> BuscarFiltroPesquisa(string nome)
        {
            var filtro = nome?.ToLower() ?? "";
            return livro => livro.Nome.ToLower().Contains(filtro);
        }

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

        public async Task<BuscaPaginadaDTO<LivroDTO>> BuscarTodos(string nome, int paginaAtual, int itensPagina)
        {
            Expression<Func<Livro, bool>> filtro = BuscarFiltroPesquisa(nome);

            var count = await _repository.BuscarCount(filtro);
            var lista = await _repository.BuscarTodos(filtro, paginaAtual, itensPagina);

            return new BuscaPaginadaDTO<LivroDTO>(
                paginaAtual,
                itensPagina,
                count,
                _parser.Parse(lista));
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