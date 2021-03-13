using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.Views
{
    public class LoginView : ContentPage
    {
        enum ViewRow { Header, Body }
        enum CampoSenhaLinha { Topo, Rodape }
        enum CampoSenhaColuna { Esquerda, Direita }

        private Color PrimaryColor = Color.FromHex("#CD7400");
        private Color SecondaryColor = Color.FromHex("#005F89");
        private Color TextColor = Color.Black;

        public LoginView()
        {
            Content = new Grid
            {
                RowSpacing = 0,
                RowDefinitions = Rows.Define(
                    (ViewRow.Header, 70),
                    (ViewRow.Body, Star)
                ),

                Children =
                {
                    new FlexLayout
                    {
                        BackgroundColor = Color.White,
                        AlignItems = FlexAlignItems.Center,

                        Children =
                        {
                            new Frame
                            {
                                BackgroundColor = Color.FromHex("#EEE9E3"),
                                HeightRequest = 40,
                                WidthRequest = 40,
                                CornerRadius = 20,
                                BorderColor = Color.FromHex("#DDD9D9"),
                                Content = new Label {
                                    Text = "MS",
                                    TextColor = SecondaryColor,
                                }
                                .TextCenterVertical()
                                .TextCenterHorizontal()
                                .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
                            }
                            .Padding(0)
                            .Margin(10, 0),

                            new StackLayout
                            {
                                Spacing = 0,
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "olá, Marcos",
                                        TextColor = SecondaryColor,
                                        FontAttributes = FontAttributes.Bold
                                    }
                                    .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Label))),

                                    new Label { Text = "ag **47 c/c/ ***79-7", TextColor = TextColor }
                                }
                            }
                            .Margin(10, 0)
                            .Grow(1),

                            new Image
                            {
                                Source = "arrow_orange"
                            }
                            .Margin(10, 0)
                        }
                    }
                    .Margins(left: 10, right: 10)
                    .Row(ViewRow.Header),

                    new FlexLayout
                    {
                        Direction = FlexDirection.Column,
                        JustifyContent = FlexJustify.SpaceBetween,
                        Background = new LinearGradientBrush
                        {
                            EndPoint = new Point(0, 1),
                            GradientStops = new GradientStopCollection
                            {
                                new GradientStop { Color = Color.FromHex("#F8801F"), Offset = 0.5f },
                                new GradientStop { Color = Color.FromHex("#E49602"), Offset = 0.9f }
                            }
                        },

                        Children =
                        {
                            new StackLayout
                            {
                                Spacing = 15,
                                Children =
                                {
                                    new Label {
                                        Text = "senha eletrônica",
                                        TextColor = Color.White,

                                    }
                                    .TextCenterHorizontal()
                                    .FontSize(Device.GetNamedSize(NamedSize.Large, typeof(Label))),

                                    new Grid
                                    {
                                        ColumnSpacing = 15,

                                        RowDefinitions = Rows.Define(
                                            (CampoSenhaLinha.Topo, 60),
                                            (CampoSenhaLinha.Rodape, 2)
                                        ),

                                        ColumnDefinitions = Columns.Define(
                                            (CampoSenhaColuna.Esquerda, 30),
                                            (CampoSenhaColuna.Direita, Star)
                                        ),

                                        Children =
                                        {
                                            new Image
                                            {
                                                Source = "lock"
                                            }
                                            .Column(CampoSenhaColuna.Esquerda)
                                            .Row(CampoSenhaLinha.Topo)
                                            .Height(40)
                                            .CenterVertical(),

                                            new Label
                                            {
                                                Text = "● ● ● ● ● ●",
                                                TextColor = Color.White
                                            }
                                            .Column(CampoSenhaColuna.Direita)
                                            .Row(CampoSenhaLinha.Topo)
                                            .FontSize(40)
                                            .CenterVertical(),

                                            new BoxView
                                            {
                                                BackgroundColor = Color.White
                                            }
                                            .Column(CampoSenhaColuna.Esquerda)
                                            .Row(CampoSenhaLinha.Rodape)
                                            .ColumnSpan(2)
                                        }
                                    },

                                    new Button {
                                        Text = "acessar",
                                        TextColor = PrimaryColor,
                                        BackgroundColor = Color.White,
                                        CornerRadius = 4,
                                        TextTransform = TextTransform.Lowercase
                                    }
                                    .Height(60)
                                    .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button))),

                                    new Button {
                                        Text = "esqueci minha senha",
                                        TextColor = Color.White,
                                        BackgroundColor = Color.Transparent,
                                        TextTransform = TextTransform.Lowercase
                                    }
                                    .Height(60)
                                    .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                                }
                            }
                            .Margin(50, 10),

                            new FlexLayout
                            {
                                JustifyContent = FlexJustify.SpaceEvenly,
                                AlignItems = FlexAlignItems.Center,

                                Children =
                                {
                                    new StackLayout
                                    {
                                        Children =
                                        {
                                            new Image
                                            {
                                                Source = "pix_outlined",
                                                HeightRequest = 30
                                            },

                                            new Label
                                            {
                                                Text = "Pix",
                                                TextColor = Color.White
                                            }
                                            .TextCenterHorizontal()
                                            .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
                                        }
                                    },

                                    new StackLayout
                                    {
                                        Children =
                                        {
                                            new Image
                                            {
                                                Source = "itoken_outlined",
                                                HeightRequest = 30
                                            },

                                            new Label
                                            {
                                                Text = "iToken",
                                                TextColor = Color.White
                                            }
                                            .TextCenterHorizontal()
                                            .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
                                        }
                                    },

                                    new StackLayout
                                    {
                                        Children =
                                        {
                                            new Image
                                            {
                                                Source = "help_outlined",
                                                HeightRequest = 30
                                            },

                                            new Label
                                            {
                                                Text = "ajuda",
                                                TextColor = Color.White
                                            }
                                            .TextCenterHorizontal()
                                            .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
                                        }
                                    }
                                }
                            }
                            .Basis(100)
                        }
                    }
                    .Row(ViewRow.Body)
                }
            };
        }
    }
}

