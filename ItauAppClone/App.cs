using System;
using System.Globalization;
using System.Threading;
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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            CreateStyles();
            var mainMenu = new MainMenu();
            MainPage = new MainView(mainMenu);
        }

        private void CreateStyles()
        {
            Resources = new ResourceDictionary
            {
                new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = AppStyle.TextColor }
                    }
                }
            };
        }
    }

    public static class AppStyle
    {
        public static Color PrimaryColor = Color.FromHex("#EB6F01");
        public static Color TextColor = Color.Black;
        public static Color ContentPageBackgroundColor = Color.FromHex("#EFE9E4");
    }
}
