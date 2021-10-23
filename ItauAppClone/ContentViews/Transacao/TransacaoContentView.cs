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

            grid.Children.Add(new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = "hoje, dia 05,\no que deseja fazer?" },

                        new FlexLayout
                        {
                            Direction = FlexDirection.Row,
                            Wrap = FlexWrap.Wrap,

                            Children =
                            {
                                ObterBotaoPequeno(),
                                ObterBotaoPequeno(),
                                ObterBotaoPequeno(),
                                ObterBotaoPequeno(),
                                ObterBotaoGrande(),
                                ObterBotaoPequeno(),
                                ObterBotaoPequeno(),
                                ObterBotaoPequeno(),
                                ObterBotaoPequeno(),
                            }
                        }
                    }
                }
            }
            .Row(GridRow.Conteudo));

            Content = grid;
        }

        private View ObterBotaoPequeno()
        {
            return new Frame
            {
                HasShadow = false,
                CornerRadius = 4,
                HeightRequest = 100,
                BackgroundColor = Color.Red
            }
            .Padding(0)
            .Margin(8)
            .Basis(new FlexBasis(0.5f, true));
        }

        private View ObterBotaoGrande()
        {
            return new Frame
            {
                HasShadow = false,
                CornerRadius = 4,
                HeightRequest = 160,
                BackgroundColor = Color.Blue
            }
            .Padding(0)
            .Margin(8)
            .Basis(new FlexBasis(1f, true));
        }
    }
}

