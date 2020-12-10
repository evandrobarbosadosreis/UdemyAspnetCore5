using System.Collections.Generic;
using System.Linq;
using webapi.DTO.Parser.Interfaces;
using webapi.Models;

namespace webapi.DTO.Parser
{
    // TODO: Refatorar para reduzir a repetição de código nos adapters

    public class LivroParser : IParser<Livro, LivroDTO>, IParser<LivroDTO, Livro>
    {
        public LivroDTO Parse(Livro source)
        {
            if (source == null)
            {
                return null;
            }

            return new LivroDTO
            {
                Id         = source.Id,
                Descricao  = source.Descricao,
                Lancamento = source.Lancamento,
                Nome       = source.Nome,
            };
        }

        public Livro Parse(LivroDTO source)
        {
            if (source == null)
            {
                return null;
            }

            return new Livro
            {
                Id         = source.Id,
                Descricao  = source.Descricao,
                Lancamento = source.Lancamento,
                Nome       = source.Nome,
            };
        }

        public IEnumerable<LivroDTO> Parse(IEnumerable<Livro> source)
        {
            if (source == null)
            {
                return null;
            }

            return source.Select(Parse);
        }

        public IEnumerable<Livro> Parse(IEnumerable<LivroDTO> source)
        {
            if (source == null)
            {
                return null;
            }

            return source.Select(Parse);
        }

    }
}