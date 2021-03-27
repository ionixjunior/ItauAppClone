using System;
using ItauAppClone.Controls;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;

namespace ItauAppClone.ContentViews.Home
{
    public class HomeContentView : ContentView
    {
        private Color PrimaryColor = Color.FromHex("#EB6F01");
        private Color TextColor = Color.Black;

        public HomeContentView()
        {
            Content = new Header();
        }
    }
}

