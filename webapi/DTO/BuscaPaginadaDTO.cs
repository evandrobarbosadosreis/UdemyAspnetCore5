using System;
using System.Collections.Generic;

namespace webapi.DTO
{
    public class BuscaPaginadaDTO<T>
    {
        public int PaginaAtual { get; }
        public int ItensPorPagina { get; }
        public int TotalPaginas { get; }
        public int TotalItens { get; }
        public IEnumerable<T> Itens { get; }

        public BuscaPaginadaDTO(int paginaAtual, int itensPorPagina, int totalItens, IEnumerable<T> itens)
        {
            PaginaAtual    = paginaAtual;
            ItensPorPagina = itensPorPagina;
            TotalItens     = totalItens;
            Itens          = itens;
            TotalPaginas   = (int) Math.Ceiling( (double) totalItens / itensPorPagina);
        } 

    }
}