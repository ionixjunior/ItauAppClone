using System;
using ItauAppClone.Controls;
using ItauAppClone.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItauAppClone
{
    public class App : Application
    {
        public App()
        {
            var mainMenu = new MainMenu();
            MainPage = new MainView(mainMenu);
        }
    }

    public static class AppStyle
    {
        public static Color PrimaryColor = Color.FromHex("#EB6F01");
        public static Color TextColor = Color.Black;
        public static Color ContentPageBackgroundColor = Color.FromHex("#EFE9E4");
    }
}
