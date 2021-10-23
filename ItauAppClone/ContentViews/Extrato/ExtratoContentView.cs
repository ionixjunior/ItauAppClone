using System;
using ItauAppClone.Interfaces;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;
using ItauAppClone.Controls;
using ItauAppClone.ViewModels;
using ItauAppClone.Models;
using ItauAppClone.Enums;
using TransacaoModel = ItauAppClone.Models.Transacao;

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

                            new ImageButton
                            {
                                Source = "fab_relatorio",
                                BackgroundColor = Color.FromHex("#007AB7"),
                                CornerRadius = 30
                            }
                            .End()
                            .Bottom()
                            .Margin(20)
                            .Width(60)
                            .Height(60)
                            .Padding(16)
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

        enum LinhaGridTransacao { Categoria, Informacoes }
        enum ColunaGridTransacao { Icone, Descricao, Valor }

        private View CarregarTemplateTransacao()
        {
            return new Frame
            {
                BackgroundColor = Color.White,
                HasShadow = false,
                CornerRadius = 6,
                Padding = 0,
                Content = new Grid
                {
                    RowDefinitions = Rows.Define(
                        (LinhaGridTransacao.Categoria, Auto),
                        (LinhaGridTransacao.Informacoes, Auto)
                    ),

                    ColumnDefinitions = Columns.Define(
                        (ColunaGridTransacao.Icone, 20),
                        (ColunaGridTransacao.Descricao, Star),
                        (ColunaGridTransacao.Valor, Auto)
                    ),

                    RowSpacing = 4,
                    ColumnSpacing = 16,

                    Children =
                    {
                        new Label() { TextColor = Color.Gray }
                        .Column(ColunaGridTransacao.Descricao)
                        .Row(LinhaGridTransacao.Categoria)
                        .FontSize(Device.GetNamedSize(NamedSize.Caption, typeof(Label)))
                        .Bind(nameof(TransacaoModel.Categoria)),

                        new Image()
                        .Bind(Image.SourceProperty, nameof(TransacaoModel.Tipo), converter: IconeDaTransacaoConverter)
                        .Column(ColunaGridTransacao.Icone)
                        .Row(LinhaGridTransacao.Informacoes)
                        .Width(20)
                        .Height(20),

                        new Label
                        {
                            LineBreakMode = LineBreakMode.TailTruncation,
                            FontAttributes = FontAttributes.Bold
                        }
                        .Column(ColunaGridTransacao.Descricao)
                        .Row(LinhaGridTransacao.Informacoes)
                        .TextCenterVertical()
                        .Bind(nameof(TransacaoModel.Descricao))
                        .Bind(Label.TextColorProperty, nameof(TransacaoModel.Tipo), converter: CorDaTransacaoConverter),

                        new Label
                        {
                            FontAttributes = FontAttributes.Bold
                        }
                        .Column(ColunaGridTransacao.Valor)
                        .Row(LinhaGridTransacao.Informacoes)
                        .TextCenterVertical()
                        .Bind(path: ".", converter: ValorTransacaoParaTextoConverter)
                        .Bind(Label.TextColorProperty, nameof(TransacaoModel.Tipo), converter: CorDaTransacaoConverter)
                    }
                }
                .Margin(12)
            };
        }

        private const string _formatacaoMonetaria = "C2";

        private FuncConverter<TransacaoModel, string> ValorTransacaoParaTextoConverter
            = new FuncConverter<TransacaoModel, string>(transacao =>
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

        private FuncConverter<TipoTransacao, string> IconeDaTransacaoConverter
            = new FuncConverter<TipoTransacao, string>(tipoTransacao =>
            {
                return tipoTransacao switch
                {
                    TipoTransacao.Entrada => "tipo_transacao_entrada",
                    TipoTransacao.Saida => "tipo_transacao_saida",
                    _ => string.Empty
                };
            });
    }
}

