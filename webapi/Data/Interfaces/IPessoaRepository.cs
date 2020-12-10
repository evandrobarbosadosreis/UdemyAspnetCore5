using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Data.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<List<Pessoa>> BuscarPorNome(string nome);
    }
}