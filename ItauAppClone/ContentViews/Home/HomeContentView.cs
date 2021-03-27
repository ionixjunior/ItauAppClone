using ItauAppClone.Controls;
using ItauAppClone.Interfaces;
using Xamarin.CommunityToolkit.Markup;
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
                    new InfoContent("arrow_orange", "Seu limite de crédito continua disponível. Toque aqui.")
                }
            };
        }
    }
}

