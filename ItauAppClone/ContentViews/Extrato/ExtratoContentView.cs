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
        enum LinhaGrid { Cabecalho, Conteudo }

        public ExtratoContentView() => Build();

        public void Build()
        {
            Margin = new Thickness(0, 0, 0, 22);

            Content = new Grid
            {
                RowDefinitions = Rows.Define(
                    (LinhaGrid.Cabecalho, 60),
                    (LinhaGrid.Conteudo, Star)
                ),
                RowSpacing = 0,

                Children =
                {
                    new Filtros().Row(LinhaGrid.Cabecalho),
                    new Grid
                    {
                        Children =
                        {
                            new CollectionView
                            {
                            },

                            new Frame
                            {
                                BackgroundColor = Color.FromHex("#007AB7"),
                                HasShadow = false,
                                CornerRadius = 30
                            }
                            .End()
                            .Bottom()
                            .Margin(20)
                            .Width(60)
                            .Height(60)
                            .Padding(0)
                        }
                    }
                    .Row(LinhaGrid.Conteudo)
                }
            };
        }
    }
}

