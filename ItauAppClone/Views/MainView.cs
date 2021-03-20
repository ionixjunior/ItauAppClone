using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ItauAppClone.Templates;
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
            tabView.SelectionChanged += OnTabViewSelectionChanged;

            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "início",
                Icon = "menu_home",
                IconSelected = "menu_home_selected",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                TextColorSelected = PrimaryColor,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new Label { Text = "Conteúdo início" }
            });
            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "extrato",
                Icon = "menu_extrato",
                IconSelected = "menu_extrato_selected",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                TextColorSelected = PrimaryColor,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new Label { Text = "Conteúdo extrato" }
            });
            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "transações",
                Icon = "menu_transacoes",
                IconSelected = "menu_transacoes_selected",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                TextColorSelected = PrimaryColor,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new Label { Text = "Conteúdo transações" }
            });
            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "serviços",
                Icon = "menu_servicos",
                IconSelected = "menu_servicos_selected",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                TextColorSelected = PrimaryColor,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new Label { Text = "Conteúdo serviços" }
            });
            tabView.TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "ajuda",
                Icon = "menu_ajuda",
                IconSelected = "menu_ajuda_selected",
                FontSize = 10,
                FontSizeSelected = 10,
                TextColor = Color.White,
                TextColorSelected = PrimaryColor,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new Label { Text = "ajuda" }
            });

            Content = tabView;
        }

        private void OnTabViewSelectionChanged(object sender, TabSelectionChangedEventArgs _)
        {
            if (sender is TabView tabView)
            {
                for (var index = 0; index < tabView.TabItems.Count; index++)
                {
                    if (index == tabView.SelectedIndex)
                    {
                        tabView.TabItems[index].TranslationY = 0;
                        tabView.TabItems[index].Paddings(0, 0, 0, 0);
                        continue;
                    }

                    tabView.TabItems[index].TranslationY = 0;
                }
            }
        }
    }
}

