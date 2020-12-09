using System.Collections.Generic;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface IPessoaService
    {
         Pessoa BuscarPorId(int id);
         IEnumerable<Pessoa> BuscarTodos();
         Pessoa Salvar(Pessoa pessoa);
         Pessoa Atualizar(Pessoa pessoa);
         void Excluir(Pessoa pessoa);
    }
}