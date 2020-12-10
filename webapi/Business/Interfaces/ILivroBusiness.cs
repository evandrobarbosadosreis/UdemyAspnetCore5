using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Business.Interfaces
{
    public interface ILivroBusiness
    {
         ValueTask<Livro> BuscarPorId(int id);
         Task<List<Livro>> BuscarTodos();
         Task<bool> Salvar(Livro livro);
         Task<bool> Atualizar(Livro livro);
         Task<bool> Excluir(int id);
         Task<bool> RegistroExiste(int id);
    }    
}