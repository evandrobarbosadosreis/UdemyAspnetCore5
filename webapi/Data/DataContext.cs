using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Livro> Livros { get; set; }

    }
}