using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.Views
{
    public class LoginView : ContentPage
    {
        enum ViewRow { Header, Body }
        enum FieldPasswordRow { Top, Bottom }
        enum FieldPasswordColumn { Left, Right }
        enum PasswordButtonColumn { First, Middle, Last }
        enum PasswordButtonRow { First, Second }

        private Color PrimaryColor = Color.FromHex("#EB6F01");
        private Color TextColor = Color.Black;

        private Grid _passwordButtonGrid;

        public LoginView()
        {
            On<iOS>().SetUseSafeArea(true);

            var passwordButtonStyle = new Style<Button>();
            passwordButtonStyle.Add(
                (Button.BackgroundColorProperty, Color.White),
                (Button.TextColorProperty, "#575757"),
                (Button.FontAttributesProperty, FontAttributes.Bold),
                (Button.TextTransformProperty, TextTransform.Lowercase),
                (Button.CornerRadiusProperty, 8)
            );

            var passwordImageButtonStyle = new Style<ImageButton>();
            passwordImageButtonStyle.Add(
                (ImageButton.BackgroundColorProperty, Color.White),
                (ImageButton.PaddingProperty, new Thickness(34, 0)),
                (ImageButton.CornerRadiusProperty, 8)
            );

            _passwordButtonGrid = new Grid
            {
                IsVisible = false,
                RowSpacing = 10,
                ColumnSpacing = 10,
                Children =
                {
                    new Button
                    {
                        Text = "0 ou 9"
                    }
                    .Style(passwordButtonStyle)
                    .Row(PasswordButtonRow.First)
                    .Column(PasswordButtonColumn.First),

                    new Button
                    {
                        Text = "1 ou 6"
                    }
                    .Style(passwordButtonStyle)
                    .Row(PasswordButtonRow.First)
                    .Column(PasswordButtonColumn.Middle),

                    new Button
                    {
                        Text = "2 ou 4"
                    }
                    .Style(passwordButtonStyle)
                    .Row(PasswordButtonRow.First)
                    .Column(PasswordButtonColumn.Last),

                    new Button
                    {
                        Text = "3 ou 5"
                    }
                    .Style(passwordButtonStyle)
                    .Row(PasswordButtonRow.Second)
                    .Column(PasswordButtonColumn.First),

                    new Button
                    {
                        Text = "7 ou 8"
                    }
                    .Style(passwordButtonStyle)
                    .Row(PasswordButtonRow.Second)
                    .Column(PasswordButtonColumn.Middle),

                    new ImageButton
                    {
                        Source = "backspace"
                    }
                    .Style(passwordImageButtonStyle)
                    .Row(PasswordButtonRow.Second)
                    .Column(PasswordButtonColumn.Last)
                }
            };

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
                                HasShadow = false,
                                BorderColor = Color.FromHex("#DDD9D9"),
                                Content = new Label {
                                    Text = "MS",
                                    TextColor = PrimaryColor,
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
                                        TextColor = PrimaryColor,
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
                                            (FieldPasswordRow.Top, 60),
                                            (FieldPasswordRow.Bottom, 2)
                                        ),

                                        ColumnDefinitions = Columns.Define(
                                            (FieldPasswordColumn.Left, 30),
                                            (FieldPasswordColumn.Right, Star)
                                        ),

                                        Children =
                                        {
                                            new Image
                                            {
                                                Source = "lock"
                                            }
                                            .Column(FieldPasswordColumn.Left)
                                            .Row(FieldPasswordRow.Top)
                                            .Height(40)
                                            .CenterVertical(),

                                            new Label
                                            {
                                                Text = "● ● ● ● ● ●",
                                                TextColor = Color.White
                                            }
                                            .Column(FieldPasswordColumn.Right)
                                            .Row(FieldPasswordRow.Top)
                                            .FontSize(Device.GetNamedSize(NamedSize.Large, typeof(Label)))
                                            .CenterVertical(),

                                            new BoxView
                                            {
                                                BackgroundColor = Color.White
                                            }
                                            .Column(FieldPasswordColumn.Left)
                                            .Row(FieldPasswordRow.Bottom)
                                            .ColumnSpan(2)
                                        },
                                    }
                                    .TapGesture(TapPasswordArea),

                                    _passwordButtonGrid,

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

        private void TapPasswordArea(TapGestureRecognizer tap)
        {
            tap.Tapped += OnPasswordAreaTapped;
        }

        private void OnPasswordAreaTapped(object _, EventArgs __)
        {
            _passwordButtonGrid.IsVisible = true;
        }
    }
}

