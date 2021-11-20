using System;
using System.Collections.Generic;
using ItauAppClone.Controls;
using ItauAppClone.Effects;
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
                                ObterBotaoPequeno("pagar", icone: "codigo_barras"),
                                ObterBotaoPequeno("fazer transferência", icone: "transferencia"),
                                ObterBotaoPequeno("DDA - boleto eletrônico", icone: "boleto_eletronico"),
                                ObterBotaoPequeno("Pix", icone: "pix", corDeFundo: Color.FromHex("#0D6EB0"), corDoTexto: Color.White),
                                ObterBotaoGrande(),
                                ObterBotaoPequeno("pagamentos automáticos", icone: "pagamento_automatico", corDeFundo: Color.FromHex("#F1F1F1")),
                                ObterBotaoPequeno("detran.sp", icone: "detran"),
                                ObterBotaoPequeno("recarga", icone: "recarga"),
                                ObterBotaoPequeno("transferência", icone: "transferencia_pessoa"),
                            }
                        }
                    }
                }
            }
            .Row(GridRow.Conteudo));

            Content = grid;
        }

        private View ObterBotaoPequeno(string descricao, string icone, Color? corDeFundo = null, Color? corDoTexto = null)
        {
            return new Frame
            {
                HasShadow = false,
                CornerRadius = 4,
                HeightRequest = 100,
                BackgroundColor = corDeFundo ?? Color.White,
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.End,
                    Children =
                    {
                        new Image { Source = icone }
                        .Start()
                        .Width(26)
                        .Height(26),

                        new Label
                        {
                            Text = descricao,
                            TextColor = corDoTexto ?? Color.Black
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
            return new CardExpandableContent(
                "próximos pagamentos",
                LineBreakMode.WordWrap,
                FontAttributes.None,
                NamedSize.Title,
                false,
                Color.Black,
                "arrow_up_gray",
                ObterSubtituloDoCabecalho(),
                new ContentView(),
                ObterRodapeProximoPagamentos()
            )
            .Padding(0)
            .Margin(8)
            .Height(160)
            .Basis(new FlexBasis(1f, true));
        }

        private View ObterSubtituloDoCabecalho()
        {
            return new StackLayout
            {
                BackgroundColor = Color.FromHex("#F1F1F1"),
                Children = {
                    new Label
                    {
                        Text = "consultar lançamentos Pix",
                        FontAttributes = FontAttributes.Bold
                    }
                    .Margin(20)
                }
            };
        }

        private IList<View> ObterRodapeProximoPagamentos()
        {
            return new List<View>
            {
                new BoxView
                {
                    HeightRequest = 1,
                    BackgroundColor = Color.FromHex("#EFE9E4")
                }
                .Margin(20, 0),

                new FlexLayout
                {
                    JustifyContent = FlexJustify.SpaceBetween,
                    AlignItems = FlexAlignItems.Start,
                    Children =
                    {
                        new Button
                        {
                            Text = "ver todos",
                            TextColor = Color.FromHex("#0D6EB0"),
                            BackgroundColor = Color.Transparent,
                            TextTransform = TextTransform.Lowercase,
                            FontAttributes = FontAttributes.Bold
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                        .Effects(new RemovePaddingButtonEffect())
                    }
                }
                .Basis(50)
                .Margins(30, 0, 30, 20)
            };
        }
    }
}

