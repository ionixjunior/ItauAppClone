using System;
using ItauAppClone.Enums;

namespace ItauAppClone.Models
{
    public class Transacao
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        public DateTime Data { get; private set; }

        public Transacao(string descricao, decimal valor, TipoTransacao tipo, DateTime data)
        {
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;
            Data = data;
        }
    }
}
