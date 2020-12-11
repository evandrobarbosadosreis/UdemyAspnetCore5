using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.DTO;

namespace webapi.Business.Interfaces
{
    public interface ILivroBusiness
    {
         ValueTask<LivroDTO> BuscarPorId(int id);
         Task<BuscaPaginadaDTO<LivroDTO>> BuscarTodos(string nome, int paginaAtual, int itensPagina);
         Task<bool> Salvar(LivroDTO source);
         Task<bool> Atualizar(LivroDTO source);
         Task<bool> Excluir(int id);
         Task<bool> RegistroExiste(int id);
    }    
}