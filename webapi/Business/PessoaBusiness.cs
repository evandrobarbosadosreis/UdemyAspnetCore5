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
    public class PessoaBusiness : IPessoaBusiness
    {
        private readonly IRepository<Pessoa> _repository;
        private readonly PessoaParser _parser;

        private Expression<Func<Pessoa, bool>> BuscarCondicaoPesquisa(string nome)
        {
            var filtro = nome?.ToLower() ?? "";
            return pessoa => pessoa.Nome.ToLower().Contains(filtro);
        }

        public PessoaBusiness(IRepository<Pessoa> repository)
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

        public async Task<BuscaPaginadaDTO<PessoaDTO>> BuscarTodos(string nome, int paginaAtual, int itensPorPagina)
        {
            Expression<Func<Pessoa, bool>> condicao = BuscarCondicaoPesquisa(nome);

            var count = await _repository.BuscarCount(condicao);
            var lista = await _repository.BuscarTodos(condicao, paginaAtual, itensPorPagina);

            return new BuscaPaginadaDTO<PessoaDTO>(
                paginaAtual,
                itensPorPagina,
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