﻿using System;
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
            BackgroundColor = AppStyle.ContentPageBackgroundColor;
            Margin = new Thickness(0, 0, 0, 20);

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
                        new Label
                        {
                            Text = "hoje, dia 05,\no que deseja fazer?"
                        }
                        .Margin(8, 16)
                        .FontSize(Device.GetNamedSize(NamedSize.Large, typeof(Label))),

                        new FlexLayout
                        {
                            Direction = FlexDirection.Row,
                            Wrap = FlexWrap.Wrap,

                            Children =
                            {
                                ObterBotaoPequeno("pagar"),
                                ObterBotaoPequeno("fazer transferência"),
                                ObterBotaoPequeno("DDA - boleto eletrônico"),
                                ObterBotaoPequeno("Pix"),
                                ObterBotaoGrande(),
                                ObterBotaoPequeno("pagamentos automáticos"),
                                ObterBotaoPequeno("detran.sp"),
                                ObterBotaoPequeno("recarga"),
                                ObterBotaoPequeno("transferência"),
                            }
                        }
                    }
                }
            }
            .Row(GridRow.Conteudo));

            Content = grid;
        }

        private View ObterBotaoPequeno(string descricao)
        {
            return new Frame
            {
                HasShadow = false,
                CornerRadius = 4,
                HeightRequest = 100,
                BackgroundColor = Color.White,
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.End,
                    Children =
                    {
                        new Image
                        {
                            BackgroundColor = Color.Orange
                        }
                        .Start()
                        .Width(26)
                        .Height(26),

                        new Label
                        {
                            Text = descricao
                        }
                    }
                }
                .Margin(16)
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
                BackgroundColor = Color.White
            }
            .Padding(0)
            .Margin(8)
            .Basis(new FlexBasis(1f, true));
        }
    }
}

