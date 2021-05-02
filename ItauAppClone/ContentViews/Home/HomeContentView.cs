using System.Collections.Generic;
using ItauAppClone.Controls;
using ItauAppClone.Effects;
using ItauAppClone.Interfaces;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.ContentViews.Home
{
    public class HomeContentView : ContentView, IReload
    {
        enum GridRow { Header, Content }

        public HomeContentView() => Build();

        public void Build()
        {
            BackgroundColor = AppStyle.ContentPageBackgroundColor;
            Margin = new Thickness(0, 0, 0, 20);

            var grid = new Grid
            {
                RowDefinitions = Rows.Define(
                    (GridRow.Header, 60),
                    (GridRow.Content, Star)
                ),
                RowSpacing = 0
            };

            grid.Children.Add(new Header().Row(GridRow.Header));
            grid.Children.Add(
                new ScrollView
                {
                    Content = new StackLayout
                    {
                        Children =
                        {
                            new CardInfoContent("currency_outlined", "Seu limite de crédito continua disponível. Toque aqui."),

                            new CardExpandableContent(
                                "saldo em conta corrente",
                                LineBreakMode.WordWrap,
                                Color.Black,
                                "arrow_up_gray",
                                GetContentFromAccountBalance(),
                                GetFooterFromAccountBalance()
                            )
                            {
                                IsVisible = true
                            },

                            new StackLayout
                            {
                                IsVisible = true,
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "atalhos"
                                    }
                                    .Margin(20, 0),

                                    new ScrollView
                                    {
                                        Orientation = ScrollOrientation.Horizontal,
                                        HorizontalScrollBarVisibility = ScrollBarVisibility.Never,

                                        Content = new FlexLayout
                                        {
                                            Children =
                                            {
                                                new Shortcut("house_outlined", "soluções para esse momento", Color.White, AppStyle.TextColor),
                                                new Shortcut("pix", "Pix", Color.FromHex("#0D6EB0"), Color.White),
                                                new Shortcut("barcode", "pagar conta", Color.White, AppStyle.TextColor),
                                                new Shortcut("plus", "criar novo atalho", Color.White, AppStyle.TextColor)
                                            }
                                        }
                                    }
                                    .Margins(0, 10, 0, 0)
                                    .Padding(10, 0)
                                }
                            },

                            new CardExpandableContent(
                                "Itaucard Click MasterCard",
                                LineBreakMode.TailTruncation,
                                Color.White,
                                "arrow_up_gray",
                                GetSubtitleFromCreditCard(),
                                GetContentFromCreditCard(),
                                GetFooterFromCreditCard()
                            )
                            {
                                IsVisible = true,
                                Background = new LinearGradientBrush
                                {
                                    StartPoint = new Point(0, 0),
                                    EndPoint = new Point(1, 1),
                                    GradientStops = new GradientStopCollection
                                    {
                                        new GradientStop
                                        {
                                            Color = Color.FromHex("#6E606B"),
                                            Offset = 0.0f
                                        },
                                        new GradientStop
                                        {
                                            Color = Color.FromHex("#282013"),
                                            Offset = 1.0f
                                        }
                                    }
                                }
                            }
                            .Margin(20, 20),

                            new CardExpandableContent(
                                "crédito",
                                LineBreakMode.WordWrap,
                                Color.Black,
                                "arrow_up_gray",
                                GetContentFromCredit(),
                                GetFooterFromCredit()
                            )
                            {
                                IsVisible = true
                            },

                            new CardExpandableContent(
                                "meus investimentos",
                                LineBreakMode.WordWrap,
                                Color.Black,
                                "arrow_up_gray",
                                GetContentFromInvestments(),
                                GetFooterFromInvestments()
                            )
                            {
                                IsVisible = true
                            },
                        }
                    }
                }
                .Row(GridRow.Content)
            );

            Content = grid;
        }

        private List<View> GetFooterFromAccountBalance()
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
                            Text = "ver extrato",
                            TextColor = Color.FromHex("#0D6EB0"),
                            BackgroundColor = Color.Transparent,
                            TextTransform = TextTransform.Lowercase,
                            FontAttributes = FontAttributes.Bold
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                        .Effects(new RemovePaddingButtonEffect()),

                        new Button
                        {
                            Text = "ver calendário",
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

        private StackLayout GetContentFromAccountBalance()
        {
            return new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "R$ 1.000,00",
                        TextColor = Color.FromHex("#486D5D")
                    }
                    .FontSize(Device.GetNamedSize(NamedSize.Title, typeof(Label))),

                    new BoxView
                    {
                        HeightRequest = 1,
                        BackgroundColor = Color.FromHex("#EFE9E4")
                    }
                    .Margins(0, 10, 0, 10),

                    new FlexLayout
                    {
                        AlignItems = FlexAlignItems.Center,
                        Children =
                        {
                            new Label
                            {
                                Text = "cheque especial *",
                                FontAttributes = FontAttributes.Bold
                            },

                            new Image
                            {
                                Source = "info_outlined"
                            }
                            .Margins(10, 0, 0, 0)
                            .Height(16)
                            .Width(16)
                        }
                    }
                    .Margins(0),

                    new Label
                    {
                        Text = "limite disponível para uso"
                    }
                    .Margins(0, 10, 0, 0),

                    new Label
                    {
                        Text = "R$ 1.000,00"
                    },

                    new Label
                    {
                        Text = "*sugeito a encargos"
                    }
                    .Margins(0, 10, 0, 20)
                    .FontSize(Device.GetNamedSize(NamedSize.Small, typeof(Label)))
                }
            }
            .Margin(20, 0);
        }


        private View GetSubtitleFromCreditCard()
        {
            return new FlexLayout
            {
                AlignItems = FlexAlignItems.Center,

                Children =
                {
                    new Image
                    {
                        Source = "mastercard_logo"
                    }
                    .Height(60),

                    new Label
                    {
                        Text = "final 1234",
                        TextColor = Color.White
                    }
                    .Margin(15, 0)
                    .FontSize(Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)))
                }
            }
            .Margin(0, 10);
        }

        private ContentView GetContentFromCreditCard()
        {
            return new ContentView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new FlexLayout
                        {
                            JustifyContent = FlexJustify.SpaceBetween,
                            Children =
                            {
                                new Label
                                {
                                    Text = "fatura aberta",
                                    TextColor = Color.White
                                },

                                new Label
                                {
                                    Text = "venc. 01 mai.",
                                    TextColor = Color.White
                                }
                            }
                        }
                        .Margin(20, 0),

                        new Label
                        {
                            Text = "R$ 500,00",
                            TextColor = Color.White
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Title, typeof(Label)))
                        .Margin(20, 0),

                        new FlexLayout
                        {
                            JustifyContent = FlexJustify.SpaceBetween,
                            Children =
                            {
                                new Label
                                {
                                    Text = "limite disponível",
                                    TextColor = Color.White
                                },

                                new Label
                                {
                                    Text = "total",
                                    TextColor = Color.White
                                }
                            }
                        }
                        .Margins(20, 20, 20, 0),

                        new ProgressBar
                        {
                            Progress = 0.75,
                            ProgressColor = Color.White,
                            BackgroundColor = Color.FromHex("#827574"),
                            HeightRequest = 5
                        }
                        .Margin(20, 0),

                        new FlexLayout
                        {
                            JustifyContent = FlexJustify.SpaceBetween,
                            Children =
                            {
                                new Label
                                {
                                    Text = "R$ 1.500,00",
                                    TextColor = Color.White
                                },

                                new Label
                                {
                                    Text = "R$ 2.000,00",
                                    TextColor = Color.White
                                }
                            }
                        }
                        .Margin(20, 0),

                        new Button
                        {
                            Text = "gerar cartão virtual",
                            TextColor = Color.White,
                            BackgroundColor = Color.Transparent,
                            TextTransform = TextTransform.Lowercase,
                            FontAttributes = FontAttributes.Bold,
                            HorizontalOptions = LayoutOptions.Start
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                        .Effects(new RemovePaddingButtonEffect())
                        .Margins(20, 20, 20, 0)
                        .Padding(0, 0),

                        new BoxView
                        {
                            HeightRequest = 1,
                            BackgroundColor = Color.FromHex("#645857")
                        }
                    }
                }
            };
        }

        private List<View> GetFooterFromCreditCard()
        {
            return new List<View>
            {
                new FlexLayout
                {
                    JustifyContent = FlexJustify.Start,
                    AlignItems = FlexAlignItems.Start,
                    Children =
                    {
                        new Button
                        {
                            Text = "pagar",
                            TextColor = Color.White,
                            BackgroundColor = Color.Transparent,
                            TextTransform = TextTransform.Lowercase,
                            FontAttributes = FontAttributes.Bold
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                        .Effects(new RemovePaddingButtonEffect()),

                        new Button
                        {
                            Text = "ver detalhes",
                            TextColor = Color.White,
                            BackgroundColor = Color.Transparent,
                            TextTransform = TextTransform.Lowercase,
                            FontAttributes = FontAttributes.Bold
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                        .Margins(30, 0, 0, 0)
                        .Effects(new RemovePaddingButtonEffect())
                    }
                }
                .Basis(60)
                .Margins(20, 0)
            };
        }


        private View GetContentFromCredit()
        {
            return new ContentView
            {
                Content = new Label
                {
                    Text = "Iê ié: não tem conteúdo para o crédito"
                }
                .CenterHorizontal()
                .CenterVertical()
            }
            .Height(100);
        }

        private IList<View> GetFooterFromCredit()
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
                            Text = "ver mais",
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
                .Margins(30, 0, 30, 20),

                new InfoContent(
                    "credit_rate_outlined",
                    "diminuímos a taxa de crédito pessoal aqui no app!",
                    hasTruncateText: true)
                {
                    BackgroundColor = Color.FromHex("#0D6EB0")
                }
                .Padding(20, 10)
            };
        }

        private View GetContentFromInvestments()
        {
            return new ContentView
            {
                Content = new Label
                {
                    Text = "Iê ié: não tem conteúdo para meus investimentos"
                }
                .CenterHorizontal()
                .CenterVertical()
            }
            .Height(100);
        }

        private IList<View> GetFooterFromInvestments()
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
                            Text = "ver detalhes",
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
                .Margins(30, 0, 30, 20),

                new InfoContent(
                    "investments_diversity",
                    "diversificar sua carteira é a melhor opção neste momento!",
                    hasArrowIcon: true,
                    hasTruncateText: true)
                {
                    BackgroundColor = Color.FromHex("#0D6EB0")
                }
                .Padding(20, 10)
            };
        }
    }
}

