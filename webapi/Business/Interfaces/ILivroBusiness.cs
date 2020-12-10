using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.DTO;

namespace webapi.Business.Interfaces
{
    public interface ILivroBusiness
    {
         ValueTask<LivroDTO> BuscarPorId(int id);
         Task<IEnumerable<LivroDTO>> BuscarTodos();
         Task<bool> Salvar(LivroDTO source);
         Task<bool> Atualizar(LivroDTO source);
         Task<bool> Excluir(int id);
         Task<bool> RegistroExiste(int id);
    }    
}