using System;
using ItauAppClone.Interfaces;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;
using ItauAppClone.Controls;
using ItauAppClone.ViewModels;
using ItauAppClone.Models;
using ItauAppClone.Enums;

namespace ItauAppClone.ContentViews.Extrato
{
    public class ExtratoContentView : ContentView, IReload
    {
        enum LinhaGrid { Cabecalho, Conteudo }

        private ExtratoContentViewModel _viewModel;

        public ExtratoContentView() => Build();

        public void Build()
        {
            BindingContext = _viewModel = new ExtratoContentViewModel();
            BackgroundColor = AppStyle.ContentPageBackgroundColor;
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
                                ItemTemplate = new DataTemplate(() => CarregarTemplateTransacao()),
                                ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical) { ItemSpacing = 10 },
                                IsGrouped = true,
                                GroupHeaderTemplate = new DataTemplate(() => CarregarTemplateDoCabecalhoDoGrupo())
                            }
                            .Bind(nameof(_viewModel.Transacoes))
                            .Margin(10, 0),

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

        private const string _formatacaoDeData = "{0:M}";
        private const string _formatacaoDeDiaDaSemana = "{0:dddd}";

        private View CarregarTemplateDoCabecalhoDoGrupo()
        {
            return new StackLayout
            {
                Children =
                {
                    new Label()
                    {
                        TextColor = Color.Black
                    }
                    .Bind(nameof(TransacoesDoDia.Data), stringFormat: _formatacaoDeData),

                    new Label
                    {
                        TextColor = Color.FromHex("#5D5753")
                    }
                    .Bind(nameof(TransacoesDoDia.Data), stringFormat: _formatacaoDeDiaDaSemana),
                }
            }
            .Paddings(0, 26, 0, 0);
        }

        private View CarregarTemplateTransacao()
        {
            return new Frame
            {
                BackgroundColor = Color.White,
                HasShadow = false,
                CornerRadius = 6,
                Padding = 0,
                HeightRequest = 50,
                Content = new FlexLayout
                {
                    AlignItems = FlexAlignItems.Center,

                    Children =
                    {
                        new Image
                        {
                            BackgroundColor = Color.Yellow
                        }
                        .Basis(40)
                        .Width(40)
                        .Height(40)
                        .Shrink(0)
                        .Margin(5),

                        new Label
                        {
                            LineBreakMode = LineBreakMode.TailTruncation
                        }
                        .Grow(1)
                        .Margin(5)
                        .Bind(nameof(Transacao.Descricao))
                        .Bind(Label.TextColorProperty, nameof(Transacao.Tipo), converter: CorDaTransacaoConverter),

                        new Label { }
                        .Shrink(0)
                        .Margin(5)
                        .Bind(path: ".", converter: ValorTransacaoParaTextoConverter)
                        .Bind(Label.TextColorProperty, nameof(Transacao.Tipo), converter: CorDaTransacaoConverter)
                    }
                }
            };
        }

        private const string _formatacaoMonetaria = "C2";

        private FuncConverter<Transacao, string> ValorTransacaoParaTextoConverter
            = new FuncConverter<Transacao, string>(transacao =>
            {
                if (transacao is { })
                {
                    return transacao.Tipo switch
                    {
                        Enums.TipoTransacao.Saida => $"- {transacao.Valor.ToString(_formatacaoMonetaria)}",
                        Enums.TipoTransacao.Entrada => transacao.Valor.ToString(_formatacaoMonetaria),
                        _ => transacao.Valor.ToString(_formatacaoMonetaria)
                    };
                }

                return string.Empty;
            });

        private FuncConverter<TipoTransacao, Color> CorDaTransacaoConverter
            = new FuncConverter<TipoTransacao, Color>(tipoTransacao =>
            {
                return tipoTransacao switch
                {
                    TipoTransacao.Entrada => Color.FromHex("#12805A"),
                    TipoTransacao.Saida => Color.Black,
                    _ => Color.Black
                };
            });
    }
}

