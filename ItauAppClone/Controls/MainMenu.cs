using System;
using ItauAppClone.ContentViews.Extrato;
using ItauAppClone.ContentViews.Home;
using ItauAppClone.ContentViews.Transacao;
using ItauAppClone.Templates;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ItauAppClone.Controls
{
    public class MainMenu : TabView
    {
        private const int TabItemSelectedTopSpace = 12;

        public MainMenu()
        {
            var width = Width;
            var tabWidth = width / 5;

            TabStripBackgroundColor = Color.White;
            TabStripPlacement = TabStripPlacement.Bottom;
            TabStripHeight = 70;
            TabContentBackgroundColor = Color.White;
            IsSwipeEnabled = false;
            
            TabItems.Add(new TabViewItem
            {
                TranslationY = TabItemSelectedTopSpace,
                TabWidth = tabWidth,
                Text = "início",
                Icon = "menu_home",
                IconSelected = "menu_home_selected",
                TextColor = Color.Black,
                TextColorSelected = Color.White,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new HomeContentView()
            });
            TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "extrato",
                Icon = "menu_extrato",
                IconSelected = "menu_extrato_selected",
                TextColor = Color.Black,
                TextColorSelected = Color.White,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new ExtratoContentView()
            });
            TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "transações",
                Icon = "menu_transacoes",
                IconSelected = "menu_transacoes_selected",
                TextColor = Color.Black,
                TextColorSelected = Color.White,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new TransacaoContentView()
            });
            TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "serviços",
                Icon = "menu_servicos",
                IconSelected = "menu_servicos_selected",
                TextColor = Color.Black,
                TextColorSelected = Color.White,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new Label { Text = "Conteúdo serviços" }
            });
            TabItems.Add(new TabViewItem
            {
                TabWidth = tabWidth,
                Text = "ajuda",
                Icon = "menu_ajuda",
                IconSelected = "menu_ajuda_selected",
                TextColor = Color.Black,
                TextColorSelected = Color.White,
                ControlTemplate = new ControlTemplate(typeof(CustomTabViewItemTemplate)),
                Content = new Label { Text = "ajuda" }
            });
        }
    }
}
