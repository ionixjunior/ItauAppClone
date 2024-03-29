﻿using System;
using System.Collections.Generic;
using ItauAppClone.Controls;
using ItauAppClone.Converters;
using ItauAppClone.Effects;
using ItauAppClone.Interfaces;
using ItauAppClone.ViewModels.Home;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.ContentViews.Home
{
    public class HomeContentView : ContentView, IReload
    {
        private HomeContentViewModel _viewModel;

        enum GridRow { Header, Content }

        public HomeContentView() => Build();

        public void Build()
        {
            BindingContext = _viewModel = new HomeContentViewModel();
            var DeveVisualizarConteudoConverterParameter = new Func<bool>(() => _viewModel.DeveVisualizarSaldoEmConta);

            var valorSaldoConta = new Span()
                .Bind(
                    Span.TextProperty,
                    nameof(_viewModel.SaldoEmConta),
                    stringFormat: "{0:N2}",
                    converter: new DeveVisualizarConteudoConverter(DeveVisualizarConteudoConverterParameter));

            var valorChequeEspecial = new Span()
                .Bind(
                    Span.TextProperty,
                    nameof(_viewModel.ChequeEspecial),
                    stringFormat: "{0:N2}",
                    converter: new DeveVisualizarConteudoConverter(DeveVisualizarConteudoConverterParameter));

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

            var textoSaldoConta = new FormattedString();
            textoSaldoConta.Spans.Add(new Span { Text = "R$ " });
            textoSaldoConta.Spans.Add(valorSaldoConta);

            var textoChequeEspecial = new FormattedString();
            textoChequeEspecial.Spans.Add(new Span { Text = "cheque especial disponível R$ " });
            textoChequeEspecial.Spans.Add(valorChequeEspecial);


            grid.Children.Add(new Header().Row(GridRow.Header));
            grid.Children.Add(
                new ScrollView
                {
                    Content = new StackLayout
                    {
                        Spacing = 0,
                        Children =
                        {
                            new StackLayout
                            {
                                BackgroundColor = AppStyle.PrimaryColor,
                                Children =
                                {
                                    new FlexLayout
                                    {
                                        Children =
                                        {
                                            new Button
                                            {
                                                Text = "saldo em conta",
                                                BackgroundColor = Color.Transparent,
                                                TextColor = Color.White,
                                                TextTransform = TextTransform.Lowercase
                                            }
                                            .Bind(
                                                Button.ImageSourceProperty,
                                                nameof(_viewModel.DeveVisualizarSaldoEmConta),
                                                convert: (bool deveVisualizarSaldoEmConta) => deveVisualizarSaldoEmConta ? "closed_eyes" : "opened_eyes" )
                                            .BindCommand(nameof(_viewModel.MostrarEsconderSaldoEmContaCommand))
                                        }
                                    },

                                    new FlexLayout
                                    {
                                        JustifyContent = FlexJustify.SpaceBetween,
                                        AlignItems = FlexAlignItems.Center,
                                        Children =
                                        {
                                            new Label
                                            {
                                                FormattedText = textoSaldoConta,
                                                TextColor = Color.White,
                                                FontAttributes = FontAttributes.Bold
                                            }
                                            .FontSize(Device.GetNamedSize(NamedSize.Large, typeof(Label))),

                                            new ImageButton
                                            {
                                                Source = "refresh",
                                                BackgroundColor = Color.Transparent
                                            }
                                            .Width(32)
                                            .Height(32)
                                            .Padding(8, 8)
                                            .Bind(IsVisibleProperty, nameof(_viewModel.DeveVisualizarSaldoEmConta))
                                        }
                                    },

                                    new BoxView
                                    {
                                        HeightRequest = 1,
                                        BackgroundColor = Color.White
                                    },

                                    new FlexLayout
                                    {
                                        JustifyContent = FlexJustify.SpaceBetween,
                                        AlignItems = FlexAlignItems.Center,
                                        Children =
                                        {
                                            new Label
                                            {
                                                TextColor = Color.White,
                                                FormattedText = textoChequeEspecial
                                            }
                                            .FontSize(Device.GetNamedSize(NamedSize.Small, typeof(Label))),

                                            new Image
                                            {
                                                Source = "arrow_right_white",
                                                HeightRequest = 12,
                                                WidthRequest = 12
                                            }
                                        }
                                    }
                                    .Paddings(0, 12, 0, 0)
                                }
                            }
                            .Padding(28),

                            new FlexLayout
                            {
                                IsVisible = true,
                                AlignItems = FlexAlignItems.Center,
                                BackgroundColor = Color.White,
                                Children =
                                {
                                    GetShortcut("house_outlined", "soluções para esse momento", Color.White),
                                    GetShortcut("pix", "Pix", Color.FromHex("#0D6EB0")),
                                    GetShortcut("barcode", "pagar conta", Color.White),
                                    GetShortcut("add", "criar novo atalho", Color.White)
                                }
                            }
                            .Height(130),

                            new CardExpandableContent(
                                "Itaucard Multiplo Mc International",
                                LineBreakMode.WordWrap,
                                FontAttributes.Bold,
                                NamedSize.Medium,
                                true,
                                Color.Black,
                                "arrow_up_gray",
                                GetSubtitleFromCreditCard(),
                                GetContentFromCreditCard(),
                                GetFooterFromCreditCard()
                            )
                            {
                                IsVisible = true
                            }
                            .Margin(20, 20),

                            new CardExpandableContent(
                                "crédito",
                                LineBreakMode.WordWrap,
                                FontAttributes.None,
                                NamedSize.Title,
                                false,
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
                                FontAttributes.None,
                                NamedSize.Title,
                                false,
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

        private static StackLayout GetShortcut(string icon, string text, Color backgroundColor)
        {
            return new StackLayout
            {
                Margin = 5,
                Children =
                {
                    new Frame
                    {
                        BackgroundColor = backgroundColor,
                        BorderColor = Color.FromHex("#D2D2D0"),
                        HasShadow = false,
                        Padding = 0,
                        CornerRadius = 14,
                        Content = new Image
                        {
                            Source = icon
                        }
                        .Height(20)
                        .Width(20)
                        .Margin(12)
                    }
                    .CenterHorizontal(),

                    new Label
                    {
                        Text = text,
                        TextColor = AppStyle.TextColor
                    }
                    .TextCenterHorizontal()
                    .FontSize(Device.GetNamedSize(NamedSize.Micro, typeof(Label))),
                }
            }
            .CenterVertical()
            .Grow(1)
            .Basis(25f);
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
            .Margin(30, 0);
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
                    .Height(30),

                    new Label
                    {
                        Text = "final 1234",
                        TextColor = Color.Black
                    }
                    .Margin(15, 0)
                    .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
                }
            }
            .Margin(30, 0);
        }

        enum GridCalendarCreditCard { Image, Content }

        private ContentView GetContentFromCreditCard()
        {
            return new ContentView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new BoxView
                        {
                            HeightRequest = 1,
                            BackgroundColor = Color.FromHex("#EAEAE7")
                        }.Margin(30, 10),

                        new FlexLayout
                        {
                            JustifyContent = FlexJustify.SpaceBetween,
                            Children =
                            {
                                new Label
                                {
                                    Text = "limite utilizado",
                                    TextColor = Color.FromHex("#5B5A58")
                                },

                                new Label
                                {
                                    Text = "disponível",
                                    TextColor = Color.FromHex("#5B5A58")
                                }
                            }
                        }
                        .Margin(35, 0),

                        new ProgressBar
                        {
                            Progress = 0.75,
                            ProgressColor = AppStyle.PrimaryColor,
                            BackgroundColor = Color.FromHex("#F0E9E6"),
                            HeightRequest = 5
                        }
                        .Margin(35, 0),

                        new FlexLayout
                        {
                            JustifyContent = FlexJustify.SpaceBetween,
                            Children =
                            {
                                new Label
                                {
                                    Text = "R$ 1.500,00",
                                    TextColor = Color.Black,
                                    FontAttributes = FontAttributes.Bold
                                },

                                new Label
                                {
                                    Text = "R$ 2.000,00",
                                    TextColor = Color.Black,
                                    FontAttributes = FontAttributes.Bold
                                }
                            }
                        }
                        .Margin(35, 0),

                        new BoxView
                        {
                            HeightRequest = 1,
                            BackgroundColor = Color.FromHex("#EAEAE7")
                        }
                        .Margin(35, 15),

                        new FlexLayout
                        {
                            JustifyContent = FlexJustify.SpaceBetween,
                            Children =
                            {
                                new Label
                                {
                                    Text = "fatura aberta",
                                    TextColor = Color.Black
                                },

                                new Label
                                {
                                    Text = "venc. 01 mai.",
                                    TextColor = Color.Black
                                }
                            }
                        }
                        .Margin(35, 0),

                        new Label
                        {
                            Text = "R$ 500,00",
                            TextColor = Color.Black,
                            FontAttributes = FontAttributes.Bold
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Title, typeof(Label)))
                        .Margin(35, 0),

                        new Frame
                        {
                            BackgroundColor = Color.FromHex("#FBF7F5"),
                            CornerRadius = 5,
                            HasShadow = false,
                            Padding = 20,
                            Content = new Grid
                            {
                                ColumnSpacing = 15,
                                ColumnDefinitions = Columns.Define(
                                    (GridCalendarCreditCard.Image, 24),
                                    (GridCalendarCreditCard.Content, Star)
                                ),

                                Children =
                                {
                                    new Image
                                    {
                                        Source = "calendar"
                                    }
                                    .Column(GridCalendarCreditCard.Image),

                                    new Label
                                    {
                                        FormattedText = new FormattedString
                                        {
                                            Spans =
                                            {
                                                new Span { Text = "compras a partir do dia " },
                                                new Span { Text = "08", FontAttributes = FontAttributes.Bold },
                                                new Span { Text = " estarão na próxima fatura" }
                                            }
                                        }
                                    }
                                    .Column(GridCalendarCreditCard.Content)
                                }
                            }
                        }
                        .Margins(35, 15, 35, 0)
                    }
                }
            };
        }

        private List<View> GetFooterFromCreditCard()
        {
            return new List<View>
            {
                new BoxView
                {
                    HeightRequest = 1,
                    BackgroundColor = Color.FromHex("#EAEAE7")
                }.Margin(30, 10),

                new FlexLayout
                {
                    JustifyContent = FlexJustify.Start,
                    AlignItems = FlexAlignItems.Start,
                    Children =
                    {
                        new Button
                        {
                            Text = "ver fatura",
                            TextColor = Color.FromHex("#0D6EB0"),
                            BackgroundColor = Color.Transparent,
                            TextTransform = TextTransform.Lowercase,
                            FontAttributes = FontAttributes.Bold
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                        .Effects(new RemovePaddingButtonEffect()),

                        new Button
                        {
                            Text = "cartão virtual",
                            TextColor = Color.FromHex("#0D6EB0"),
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
                .Margins(35, 0)
            };
        }


        private View GetContentFromCredit()
        {
            return new ContentView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "valores pré-aprovados e válidos para esta data"
                        }
                        .Margin(0, 5),

                        new BoxView
                        {
                            HeightRequest = 1,
                            BackgroundColor = Color.FromHex("#EFE9E4")
                        },

                        new FlexLayout
                        {
                            JustifyContent = FlexJustify.SpaceBetween,
                            Children =
                            {
                                new StackLayout
                                {
                                    Children =
                                    {
                                        new Label
                                        {
                                            Text = "Crédito Consignado"
                                        }
                                        .TextStart()
                                        .FontSize(Device.GetNamedSize(NamedSize.Small, typeof(Label))),

                                        new Label
                                        {
                                            Text = "R$ 19.440,00",
                                            FontAttributes = FontAttributes.Bold
                                        }
                                    }
                                }
                                .AlignSelf(FlexAlignSelf.Start),

                                new Button
                                {
                                    Text = "simular",
                                    TextColor = Color.FromHex("#0D6EB0"),
                                    BackgroundColor = Color.Transparent,
                                    TextTransform = TextTransform.Lowercase,
                                    FontAttributes = FontAttributes.Bold
                                }
                                .AlignSelf(FlexAlignSelf.Center)
                            }
                        }
                        .Margin(0, 5)
                        .Height(70),

                        new BoxView
                        {
                            HeightRequest = 1,
                            BackgroundColor = Color.FromHex("#EFE9E4")
                        },

                        new FlexLayout
                        {
                            JustifyContent = FlexJustify.SpaceBetween,
                            Children =
                            {
                                new StackLayout
                                {
                                    Children =
                                    {
                                        new Label
                                        {
                                            Text = "Crédito Pessoal"
                                        }
                                        .TextStart()
                                        .FontSize(Device.GetNamedSize(NamedSize.Small, typeof(Label))),

                                        new Label
                                        {
                                            Text = "R$ 6.020,00",
                                            FontAttributes = FontAttributes.Bold
                                        }
                                    }
                                }
                                .AlignSelf(FlexAlignSelf.Start),

                                new Button
                                {
                                    Text = "simular",
                                    TextColor = Color.FromHex("#0D6EB0"),
                                    BackgroundColor = Color.Transparent,
                                    TextTransform = TextTransform.Lowercase,
                                    FontAttributes = FontAttributes.Bold
                                }
                                .AlignSelf(FlexAlignSelf.Center)
                            }
                        }
                        .Margin(0, 5)
                        .Height(70),

                        new BoxView
                        {
                            HeightRequest = 1,
                            BackgroundColor = Color.FromHex("#EFE9E4")
                        }
                    }
                }
                .Margin(20, 0)
            };
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
                    "coins",
                    "dinheiro na hora! comece a pagar em até 90 dias",
                    hasTruncateText: true)
                {
                    Background = new LinearGradientBrush
                    {
                        StartPoint = new Point(0, 0),
                        EndPoint = new Point(1, 1),
                        GradientStops = new GradientStopCollection
                        {
                            new GradientStop
                            {
                                Color = Color.FromHex("#063562"),
                                Offset = 0.0f
                            },
                            new GradientStop
                            {
                                Color = Color.FromHex("#1261A5"),
                                Offset = 0.7f
                            }
                        }
                    }
                }
                .Paddings(20, 20, 0, 20)
            };
        }

        private View GetContentFromInvestments()
        {
            return new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "total investido"
                    },

                    new Label
                    {
                        Text = "R$ 507,92",
                        TextColor = Color.FromHex("#1D6548")
                    }
                    .FontSize(Device.GetNamedSize(NamedSize.Title, typeof(Label))),

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
                            new FlexLayout
                            {
                                Direction = FlexDirection.Column,
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "Poupança",
                                        VerticalTextAlignment = TextAlignment.End
                                    }
                                    .Grow(1),

                                    new FlexLayout
                                    {
                                        Children =
                                        {
                                            new BoxView
                                            {
                                                BackgroundColor = Color.FromHex("#1E4581"),
                                                CornerRadius = 5
                                            }
                                            .Width(10)
                                            .Height(10)
                                            .Margins(0, 10, 0, 0),

                                            new Label
                                            {
                                                Text = "R$ 507,92",
                                                FontAttributes = FontAttributes.Bold
                                            }
                                            .Margins(10, 5, 0, 0)
                                        }
                                    }
                                    .Grow(1)
                                }
                            }
                            .Grow(1),

                            new Label
                            {
                                Text = "100%"
                            }
                            .TextEnd()
                            .Grow(1)
                        }
                    }
                    .Height(140)
                }
            }
            .Margin(20, 0);
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
                .Margins(20, 0, 30, 20),

                new BoxView
                {
                    HeightRequest = 1,
                    BackgroundColor = Color.FromHex("#EFE9E4")
                }
                .Margin(20, 0),

                new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Seu perfil expirou",
                            TextColor = AppStyle.PrimaryColor,
                            FontAttributes = FontAttributes.Bold
                        },

                        new Label
                        {
                            Text = "Mantenha seu perfil de investidor atualizado para continuarmos sugerindo os investimentos mais adequados para você."
                        }
                        .FontSize(Device.GetNamedSize(NamedSize.Small, typeof(Label))),

                        new FlexLayout
                        {
                            AlignItems = FlexAlignItems.Start,
                            Children =
                            {
                                new Button
                                {
                                    Text = "responder",
                                    TextColor = Color.FromHex("#0D6EB0"),
                                    BackgroundColor = Color.Transparent,
                                    TextTransform = TextTransform.Lowercase,
                                    FontAttributes = FontAttributes.Bold
                                }
                                .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                                .Effects(new RemovePaddingButtonEffect()),

                                new Button
                                {
                                    Text = "agora não",
                                    TextColor = Color.FromHex("#0D6EB0"),
                                    BackgroundColor = Color.Transparent,
                                    TextTransform = TextTransform.Lowercase,
                                    FontAttributes = FontAttributes.Bold
                                }
                                .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Button)))
                                .Effects(new RemovePaddingButtonEffect())
                                .Margins(30, 0, 0, 0)
                            }
                        }
                        .Basis(50)
                    }
                }
                .Paddings(20, 20, 20, 10)
            };
        }
    }
}

