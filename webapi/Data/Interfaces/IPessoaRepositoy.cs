using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Data.Interfaces
{
    public interface IPessoaRepository
    {
         Task<Pessoa> BuscarPorId(int id);
         Task<IEnumerable<Pessoa>> BuscarTodos();
         Task<bool> Salvar(Pessoa pessoa);
         Task<bool> Atualizar(Pessoa pessoa);
         Task<bool> Excluir(Pessoa pessoa);
         Task<bool> Excluir(int id);
    }
}