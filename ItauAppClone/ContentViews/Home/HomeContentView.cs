using System.Collections.Generic;
using ItauAppClone.Controls;
using ItauAppClone.Interfaces;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.ContentViews.Home
{
    public class HomeContentView : ContentView, IReload
    {
        enum GridColumn { Left, Right }

        public HomeContentView() => Build();

        public void Build()
        {
            BackgroundColor = AppStyle.ContentPageBackgroundColor;

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Header(),
                        new InfoContent("currency_outlined", "Seu limite de crédito continua disponível. Toque aqui."),

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

                        //new Frame
                        //{
                        //    IsVisible = true,
                        //    HasShadow = false,
                        //    CornerRadius = 5,
                        //    Content = GetContentFromAccountBalance()
                        //}
                        //.Margin(20),

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
                                            new Shortcut("", "criar novo atalho", Color.White, AppStyle.TextColor)
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
                            GetContentFromCreditCard(),
                            GetFooterFromCreditCard()
                        )
                        {
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
                    }
                }
            };
        }

        private List<View> GetFooterFromAccountBalance()
        {
            return new List<View>
            {
                new BoxView
                {
                    HeightRequest = 1,
                    BackgroundColor = Color.FromHex("#EFE9E4")
                },

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
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button))),

                        new Button
                        {
                            Text = "ver calendário",
                            TextColor = Color.FromHex("#0D6EB0"),
                            BackgroundColor = Color.Transparent,
                            TextTransform = TextTransform.Lowercase,
                            FontAttributes = FontAttributes.Bold
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                    }
                }
                .Basis(40)
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
            };
        }

        private ContentView GetContentFromCreditCard()
        {
            return new ContentView { Content = new Label { Text = "teste", TextColor = Color.White } };
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
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button))),

                        new Button
                        {
                            Text = "ver detalhes",
                            TextColor = Color.White,
                            BackgroundColor = Color.Transparent,
                            TextTransform = TextTransform.Lowercase,
                            FontAttributes = FontAttributes.Bold
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                    }
                }
                .Basis(40)
            };
        }
    }
}

