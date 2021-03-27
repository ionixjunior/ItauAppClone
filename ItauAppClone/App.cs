using System;
using ItauAppClone.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItauAppClone
{
    public class App : Application
    {
        public App()
        {
            MainPage = new MainView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }

    public static class AppStyle
    {
        public static Color PrimaryColor = Color.FromHex("#EB6F01");
        public static Color TextColor = Color.Black;
    }
}
