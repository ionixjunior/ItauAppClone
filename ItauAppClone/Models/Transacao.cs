using System;
using ItauAppClone.Enums;

namespace ItauAppClone.Models
{
    public record Transacao(
        string Descricao,
        decimal Valor,
        TipoTransacao Tipo,
        DateTime Data);
}
