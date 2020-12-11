using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Data.Interfaces
{
    public interface IRepository<TEntidade> where TEntidade : Entidade
    {
         ValueTask<TEntidade> BuscarPorId(int id);
         Task<int> BuscarCount(Expression<Func<TEntidade, bool>> filtro);
         Task<List<TEntidade>> BuscarTodos(Expression<Func<TEntidade, bool>> filtro, int paginaAtual, int itensPorPagina);
         Task<bool> Salvar(TEntidade entidade);
         Task<bool> Atualizar(TEntidade entidade);
         Task<bool> Excluir(int id);
         Task<bool> RegistroExiste(int id);
    }
}