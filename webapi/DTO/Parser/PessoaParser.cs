using System.Collections.Generic;
using System.Linq;
using webapi.DTO.Parser.Interfaces;
using webapi.Models;

namespace webapi.DTO.Parser
{
    // TODO: Refatorar para reduzir a repetição de código nos adapters

    public class PessoaParser : IParser<Pessoa, PessoaDTO>, IParser<PessoaDTO, Pessoa>
    {
        public PessoaDTO Parse(Pessoa source)
        {

            if (source == null)
            {
                return null;
            }

            return new PessoaDTO
            {
                Id        = source.Id,
                Endereco  = source.Endereco,
                Nome      = source.Nome,
                Sobrenome = source.Sobrenome
            };
        }

        public Pessoa Parse(PessoaDTO source)
        {
            if (source == null)
            {
                return null;
            }

            return new Pessoa
            {
                Id        = source.Id,
                Endereco  = source.Endereco,
                Nome      = source.Nome,
                Sobrenome = source.Sobrenome
            };
        }

        public IEnumerable<Pessoa> Parse(IEnumerable<PessoaDTO> source)
        {
            if (source == null)
            {
                return null;
            }

            return source.Select(Parse);
        }

        public IEnumerable<PessoaDTO> Parse(IEnumerable<Pessoa> source)
        {
            if (source == null)
            {
                return null;
            }

            return source.Select(Parse);
        }        
    }
}