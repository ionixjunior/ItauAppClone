using System;
using System.Collections.Generic;

namespace ItauAppClone.Models
{
    public record TransacoesDoDia(
        DateTime Data,
        decimal SaldoDoDia,
        List<Transacao> Transacoes);
}
