using System;
using ItauAppClone.Interfaces;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;
using ItauAppClone.Controls;

namespace ItauAppClone.ContentViews.Extrato
{
    public class ExtratoContentView : ContentView, IReload
    {
        enum GridRow { Header, Content }

        public ExtratoContentView() => Build();

        public void Build()
        {
            Content = new Grid
            {
                RowDefinitions = Rows.Define(
                    (GridRow.Header, 60),
                    (GridRow.Content, Star)
                ),
                RowSpacing = 0,

                Children =
                {
                    new Filtros()
                }
            };
        }
    }
}

