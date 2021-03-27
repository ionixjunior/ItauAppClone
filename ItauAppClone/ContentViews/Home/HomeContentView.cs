using ItauAppClone.Controls;
using ItauAppClone.Interfaces;
using Xamarin.Forms;

namespace ItauAppClone.ContentViews.Home
{
    public class HomeContentView : ContentView, IReload
    {
        public HomeContentView() => Build();

        public void Build()
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Header()
                }
            };
        }
    }
}

