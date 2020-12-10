using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Data.Interfaces
{
    public interface IRepository<TEntidade> where TEntidade : Entidade
    {
         ValueTask<TEntidade> BuscarPorId(int id);
         Task<List<TEntidade>> BuscarTodos();
         Task<bool> Salvar(TEntidade entidade);
         Task<bool> Atualizar(TEntidade entidade);
         Task<bool> Excluir(int id);
         Task<bool> RegistroExiste(int id);
    }
}