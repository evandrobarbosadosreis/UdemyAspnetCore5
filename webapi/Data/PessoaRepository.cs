using webapi.Data.Interfaces;
using webapi.Models;

namespace webapi.Data
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(DataContext context) : base(context)
        { }
    }
}

