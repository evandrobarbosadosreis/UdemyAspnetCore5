using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly DataContext _context;

        public PessoaService(DataContext context)
        {
            _context = context;
        }

        public Pessoa BuscarPorId(int id)
        {
            return _context.Pessoas.Find(id);
        }

        public IEnumerable<Pessoa> BuscarTodos()
        {
            return _context.Pessoas.ToList();
        }

        public Pessoa Salvar(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return pessoa;
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {
            var pessoadb = BuscarPorId(pessoa.Id);
            if (pessoadb == null)
            {
                return null;
            }
            _context.Entry(pessoadb).CurrentValues.SetValues(pessoa);
            _context.SaveChanges();
            return pessoadb;
        }  

        public void Excluir(Pessoa pessoa)
        {
            _context.Remove(pessoa);
            _context.SaveChanges();
        }

    }
}