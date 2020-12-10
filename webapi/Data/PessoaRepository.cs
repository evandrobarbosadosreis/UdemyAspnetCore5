using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Data.Interfaces;
using webapi.Models;

namespace webapi.Data
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(DataContext context) : base(context)
        { }

        public Task<List<Pessoa>> BuscarPorNome(string nome)
        {
            var filtro = nome?.ToLower() ?? "";
            return _context
                .Pessoas
                .Where(p => p.Nome.ToLower().Contains(filtro))
                .ToListAsync();
        }
    }
}

