using System.Collections.Generic;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class PessoaService : IPessoaService
    {
        public Pessoa Atualizar(Pessoa pessoa)
        {
            return pessoa;
        }

        public Pessoa BuscarPorId(int id)
        {
            return new Pessoa
            {
                Id        = id,
                Nome      = "Nome",
                Sobrenome = "Sobrenome",
                Endereco  = "Endereço",
            };
        }

        public IEnumerable<Pessoa> BuscarTodos()
        {
            return new List<Pessoa>
            {
                new Pessoa { Id = 1, Nome = "Nome", Sobrenome = "Sobrenome", Endereco = "Endereço" },
                new Pessoa { Id = 2, Nome = "Nome", Sobrenome = "Sobrenome", Endereco = "Endereço" },
                new Pessoa { Id = 3, Nome = "Nome", Sobrenome = "Sobrenome", Endereco = "Endereço" },
                new Pessoa { Id = 4, Nome = "Nome", Sobrenome = "Sobrenome", Endereco = "Endereço" },
                new Pessoa { Id = 5, Nome = "Nome", Sobrenome = "Sobrenome", Endereco = "Endereço" },
            };
        }

        public void Excluir(Pessoa pessoa)
        {
        }

        public Pessoa Salvar(Pessoa pessoa)
        {
            return pessoa;
        }
    }
}