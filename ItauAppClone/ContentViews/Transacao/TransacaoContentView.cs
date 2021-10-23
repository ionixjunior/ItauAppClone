using System;
using ItauAppClone.Controls;
using ItauAppClone.Interfaces;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.ContentViews.Transacao
{
    public class TransacaoContentView : ContentView, IReload
    {
        enum GridRow { Cabecalho, Conteudo }

        public TransacaoContentView() => Build();

        public void Build()
        {
            var grid = new Grid
            {
                RowDefinitions = Rows.Define(
                    (GridRow.Cabecalho, 60),
                    (GridRow.Conteudo, Star)
                ),
                RowSpacing = 0
            };

            grid.Children.Add(new Header().Row(GridRow.Cabecalho));

            Content = grid;
        }
    }
}

