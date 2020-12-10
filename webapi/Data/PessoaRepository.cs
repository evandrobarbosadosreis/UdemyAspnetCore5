using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Data.Interfaces;
using webapi.Models;

namespace webapi.Data
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly DataContext _context;

        public PessoaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Atualizar(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return false;
            }
            var pessoaDB = await BuscarPorId(pessoa.Id);
            _context.Entry(pessoaDB).CurrentValues.SetValues(pessoa);
            var registrosAfetados = await _context.SaveChangesAsync();
            return registrosAfetados > 0;
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<IEnumerable<Pessoa>> BuscarTodos()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<bool> Excluir(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return false;
            }                
            _context.Remove(pessoa);
            int registrosAfetados = await _context.SaveChangesAsync();
            return registrosAfetados > 0;                
        }

        public async Task<bool> Excluir(int id)
        {
            var pessoa = await BuscarPorId(id);
            return await Excluir(pessoa);
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Pessoas.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> Salvar(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return false;
            }
            await _context.Pessoas.AddAsync(pessoa);
            int registrosAfetados = await _context.SaveChangesAsync();
            return registrosAfetados > 0;            
        }
    }
}

