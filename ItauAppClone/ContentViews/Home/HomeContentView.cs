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

            var expander = GetExpander();
            expander.Tapped += OnExpanderTapped;

            Content = new ScrollView
            {
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
                                    expander,

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
                        .Margin(20),

                        new StackLayout
                        {
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
                                            CreateFrame("house_outlined", "soluções para esse momento", Color.White, AppStyle.TextColor),
                                            CreateFrame("pix", "Pix", Color.FromHex("#0D6EB0"), Color.White),
                                            CreateFrame("barcode", "pagar conta", Color.White, AppStyle.TextColor),
                                            CreateFrame("", "criar novo atalho", Color.White, AppStyle.TextColor)
                                        }
                                    }
                                }
                                .Margins(0, 10, 0, 0)
                                .Padding(10, 0)
                            }
                        }
                    }
                }
            };
        }

        private static Frame CreateFrame(string icon, string text, Color backgroundColor, Color textColor)
        {
            return new Frame
            {
                BackgroundColor = backgroundColor,
                HasShadow = false,
                CornerRadius = 10,
                Content = new StackLayout
                {
                    Margin = 5,
                    Children =
                    {
                        new Image
                        {
                            Source = icon
                        }
                        .Height(24)
                        .Width(24),

                        new Label
                        {
                            Text = text,
                            TextColor = textColor
                        }
                        .TextCenterHorizontal()
                        .FontSize(Device.GetNamedSize(NamedSize.Small, typeof(Label))),
                    }
                }
                .CenterVertical()
            }
            .Padding(0)
            .Margins(10, 0)
            .Height(120)
            .Width(120);
        }

        private Label _expanderText;
        private Image _expanderArrowImage;
        private const double _imageRotateExpanded = 0;
        private const double _imageRotateNotExpanded = 180;
        private const string _textExpanded = "ocultar";
        private const string _textNotExpanded = "expandir";

        private Expander GetExpander()
        {
            _expanderText = new Label
            {
                Text = _textNotExpanded
            };

            _expanderArrowImage = new Image
            {
                Source = "arrow_up_gray",
                Rotation = _imageRotateNotExpanded
            }
            .Margins(6, 0, 0, 0)
            .Height(12)
            .Width(12);

            return new Expander
            {
                Header = new FlexLayout
                {
                    JustifyContent = FlexJustify.SpaceBetween,
                    AlignItems = FlexAlignItems.Start,
                    Children =
                    {
                        new FlexLayout
                        {
                            Children =
                            {
                                new Label
                                {
                                    Text = "saldo em conta corrente"
                                }
                                .FontSize(Device.GetNamedSize(NamedSize.Title, typeof(Label)))
                            }
                        }
                        .Grow(2),

                        new FlexLayout
                        {
                            JustifyContent = FlexJustify.End,
                            AlignItems = FlexAlignItems.Start,
                            Children =
                            {
                                _expanderText,
                                _expanderArrowImage
                            }
                        }
                        .Margins(0, 10, 0, 0)
                        .Grow(1)
                    }
                }
                .Height(85),

                Content = new StackLayout
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
            };
        }

        private void OnExpanderTapped(object sender, System.EventArgs e)
        {
            if (sender is Expander expander)
            {
                _expanderText.Text = expander.IsExpanded ? _textExpanded : _textNotExpanded;
                _expanderArrowImage.Rotation = expander.IsExpanded ? _imageRotateExpanded : _imageRotateNotExpanded;
            }
        }
    }
}

