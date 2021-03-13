using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
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

                            new Path
                            {
                                Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString("M2 2L15 15.5L28.5 2"),
                                Stroke = new SolidColorBrush(SecondaryColor),
                                StrokeThickness = 2
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
                                            new Path
                                            {
                                                Data = new GeometryGroup
                                                {
                                                    Children =
                                                    {
                                                        (Geometry)new PathGeometryConverter().ConvertFromInvariantString("M12 27.2172V24.7172H14V27.2172H15V28.2172H11V27.2172H12Z"),
                                                        (Geometry)new PathGeometryConverter().ConvertFromInvariantString("M6 8.71729C6 2.21725 16 -4.78278 20 8.71729"),
                                                        (Geometry)new PathGeometryConverter().ConvertFromInvariantString("M22 11.7172H3.5C1.81623 12.6996 1.29051 13.4777 1 15.2172V31.2172C1.22806 32.8988 1.80247 33.6559 3.5 34.7172H12.5H22C23.7617 33.8894 24.5086 33.0966 25.5 31.2172V15.2172C24.6561 13.2005 23.9275 12.389 22 11.7172Z"),
                                                        new EllipseGeometry
                                                        {
                                                            Center = new Point(x: 13, y: 22.2172),
                                                            RadiusX = 2.5,
                                                            RadiusY = 2.5,
                                                        }
                                                    }
                                                },
                                                Stroke = Brush.White,
                                                StrokeThickness = 2
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
                                                Source = "login_pix",
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
                                                Source = "login_itoken",
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
                                                Source = "login_ajuda",
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

