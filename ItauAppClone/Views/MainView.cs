using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ItauAppClone.Views
{
    public class MainView : ContentPage
    {
        private Color PrimaryColor = Color.FromHex("#EB6F01");

        public MainView()
        {
            var width = Width;
            var tabWidth = width / 5;

            var tabView = new TabView
            {
                TabStripBackgroundColor = PrimaryColor,
                TabStripPlacement = TabStripPlacement.Bottom,
                TabStripHeight = 80
            };
            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "início",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                Content = new Label { Text = "Conteúdo início" }
            });
            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "extrato",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                Content = new Label { Text = "Conteúdo extrato" }
            });
            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "transações",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                Content = new Label { Text = "Conteúdo transações" }
            });
            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "serviços",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                Content = new Label { Text = "Conteúdo serviços" }
            });
            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "ajuda",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                Content = new Label { Text = "ajuda" }
            });

            Content = tabView;
        }
    }
}

