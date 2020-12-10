using System;

namespace webapi.DTO
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Lancamento { get; set; }
    }
}