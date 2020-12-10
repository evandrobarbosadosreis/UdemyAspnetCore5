using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Business.Interfaces
{
    public interface IPessoaBusiness
    {
         ValueTask<Pessoa> BuscarPorId(int id);
         Task<List<Pessoa>> BuscarTodos();
         Task<bool> Salvar(Pessoa pessoa);
         Task<bool> Atualizar(Pessoa pessoa);
         Task<bool> Excluir(int id);
         Task<bool> RegistroExiste(int id);
    }   
}