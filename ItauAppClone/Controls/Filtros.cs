using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;

namespace ItauAppClone.Controls
{
    public class Filtros : ScrollView
    {
        public Filtros()
        {
            Orientation = ScrollOrientation.Horizontal;
            HorizontalScrollBarVisibility = ScrollBarVisibility.Never;
            Padding = new Thickness(5, 0);

            Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Children =
                {
                    CriarBotaoFiltro("filtros", textoBadge: "1"),
                    CriarBotaoFiltro("somente c/c", estaSelecionado: true),
                    CriarBotaoFiltro("lançamentos"),
                    CriarBotaoFiltro("período"),
                    CriarBotaoFiltro("categorias"),
                    CriarBotaoFiltro("configuração"),
                }
            }
            .CenterVertical();
        }

        private Frame CriarBotaoFiltro(string texto, bool estaSelecionado = false, string textoBadge = null)
        {
            var frame = new Frame
            {
                HasShadow = false,
                Content = CriarConteudoFiltro(texto, estaSelecionado, textoBadge),
                CornerRadius = 5,
                BorderColor = Color.FromHex("#dddddd")
            }
            .Padding(25, 14);

            if (estaSelecionado)
            {
                frame.BackgroundColor = AppStyle.PrimaryColor;
            }

            return frame;
        }

        private View CriarConteudoFiltro(string texto, bool estaSelecionado, string textoBadge)
        {
            var labelTexto = new Label { Text = texto };

            var layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { labelTexto }
            };

            if (estaSelecionado)
            {
                labelTexto.TextColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(textoBadge))
                layout.Children.Add(new Image { Source = "arrow_up_gray" });
            else
            {
                layout.Children.Add(
                    new Frame
                    {
                        BackgroundColor = AppStyle.PrimaryColor,
                        HasShadow = false,
                        Padding = 0,
                        HeightRequest = 22,
                        WidthRequest = 22,
                        CornerRadius = 11,
                        Content = new Label
                        {
                            Text = textoBadge,
                            TextColor = Color.White
                        }
                        .CenterHorizontal()
                        .CenterVertical()
                        .FontSize(Device.GetNamedSize(NamedSize.Small, typeof(Label)))
                    }
                );
            }

            return layout;
        }
    }
}
