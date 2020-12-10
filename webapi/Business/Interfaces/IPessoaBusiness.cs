using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.DTO;
using webapi.Models;

namespace webapi.Business.Interfaces
{
    public interface IPessoaBusiness
    {
         ValueTask<PessoaDTO> BuscarPorId(int id);
         Task<IEnumerable<PessoaDTO>> BuscarTodos();
         Task<bool> Salvar(PessoaDTO source);
         Task<bool> Atualizar(PessoaDTO source);
         Task<bool> Excluir(int id);
         Task<bool> RegistroExiste(int id);
    }   
}