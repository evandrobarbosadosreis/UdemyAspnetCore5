using System;

namespace webapi.Models
{
    public class Livro : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Lancamento { get; set; }
    }
}