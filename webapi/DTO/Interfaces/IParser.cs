using System.Collections;
using System.Collections.Generic;

namespace webapi.DTO.Parser.Interfaces
{
    public interface IParser<TOrigem, TDestino>
    {
        TDestino Parse(TOrigem source);
        IEnumerable<TDestino> Parse(IEnumerable<TOrigem> source);
         
    }
}