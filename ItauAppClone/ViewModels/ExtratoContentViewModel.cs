using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ItauAppClone.Enums;
using ItauAppClone.Models;

namespace ItauAppClone.ViewModels
{
    public class ExtratoContentViewModel
    {
        public ObservableCollection<Transacao> Transacoes { get; }

        public ExtratoContentViewModel()
        {
            Transacoes = new ObservableCollection<Transacao>(CarregarTransacoes());
        }

        private IList<Transacao> CarregarTransacoes()
        {
            return new List<Transacao>
            {
                new Transacao("ted 123456", 1512.07m, TipoTransacao.Entrada, new DateTime(2021, 2, 26)),
                new Transacao("int ted d 957609", 977.00m, TipoTransacao.Saida, new DateTime(2021, 2, 25)),
                new Transacao("ted 102.0003marcos w c s", 1000.00m, TipoTransacao.Entrada, new DateTime(2021, 2, 25)),
                new Transacao("int ted d 545387", 500.00m, TipoTransacao.Saida, new DateTime(2021, 2, 23))
            };
        }
    }
}
