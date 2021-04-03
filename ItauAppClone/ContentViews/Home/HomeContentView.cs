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
            Content = new StackLayout
            {
                Children =
                {
                    new Header(),
                    new InfoContent("currency_outlined", "Seu limite de crédito continua disponível. Toque aqui."),

                    new Frame
                    {
                        HasShadow = false,
                        Content = new FlexLayout
                        {
                            Direction = FlexDirection.Column,
                            Children =
                            {
                                new Expander
                                {
                                    Header = new FlexLayout
                                    {
                                        JustifyContent = FlexJustify.SpaceBetween,
                                        Children =
                                        {
                                            new Label
                                            {
                                                Text = "Saldo em conta corrente"
                                            }
                                            .FontSize(Device.GetNamedSize(NamedSize.Title, typeof(Label))),

                                            new FlexLayout
                                            {
                                                JustifyContent = FlexJustify.End,
                                                AlignItems = FlexAlignItems.Center,
                                                Children =
                                                {
                                                    new Label
                                                    {
                                                        Text = "expandir"
                                                    },

                                                    new Image
                                                    {
                                                        Source = "arrow_up_gray"
                                                    }
                                                    .Margins(6, 0, 0, 0)
                                                    .Height(12)
                                                    .Width(12)
                                                }
                                            }
                                            .Basis(150)
                                        }
                                    },

                                    Content = new StackLayout
                                    {
                                        Children =
                                        {
                                            new BoxView
                                            {
                                                HeightRequest = 1,
                                                BackgroundColor = Color.FromHex("#EFE9E4")
                                            },

                                            new FlexLayout
                                            {
                                                AlignItems = FlexAlignItems.Center,
                                                Children =
                                                {
                                                    new Label
                                                    {
                                                        Text = "Cheque especial *"
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
                                            .Margins(0, 10, 0, 10),

                                            new Label
                                            {
                                                Text = "limite disponível para uso"
                                            },

                                            new Label
                                            {
                                                Text = "R$ 1.000,00"
                                            },

                                            new Label
                                            {
                                                Text = "*sugeito a encargos"
                                            }
                                            .Margins(0, 10, 0, 20)
                                        }
                                    }
                                },

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
                            }
                        }
                    }
                    .Margin(20)
                }
            };
        }
    }
}

