using System;
using System.Collections.Generic;

namespace ItauAppClone.Models
{
    public class TransacoesDoDia : List<Transacao>
    {
        public DateTime Data { get; private set; }
        public decimal SaldoDoDia { get; private set; }

        public TransacoesDoDia(DateTime data, decimal saldoDoDia, List<Transacao> transacoes) : base(transacoes)
        {
            Data = data;
            SaldoDoDia = saldoDoDia;
        }
    }
}
