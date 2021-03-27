using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ItauAppClone.ContentViews.Home;
using ItauAppClone.Interfaces;
using ItauAppClone.Templates;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ItauAppClone.Views
{
    public class MainView : ContentPage
    {
        private const int TabItemSelectedTopSpace = 12;
        private Color PrimaryColor = Color.FromHex("#EB6F01");
        private readonly TabView _tabView;

        public MainView(TabView tabView)
        {
            _tabView = tabView;
            Build();
        }

        private void Build()
        {
            _tabView.SelectionChanged += OnTabViewSelectionChanged;
#if DEBUG
            ReloadTabItems();
#endif
            SafeAreaEffect.SetSafeArea(_tabView, new SafeArea(false, true, false, true));
            BackgroundColor = PrimaryColor;

            Content = _tabView;
        }

        private void ReloadTabItems()
        {
            foreach (var tabItem in _tabView.TabItems)
            {
                if (tabItem.Content is IReload reload)
                    reload.Build();
            }
        }

        private void OnTabViewSelectionChanged(object sender, TabSelectionChangedEventArgs _)
        {
            if (sender is TabView tabView)
            {
                for (var index = 0; index < tabView.TabItems.Count; index++)
                {
                    if (index == tabView.SelectedIndex)
                    {
                        tabView.TabItems[index].TranslationY = TabItemSelectedTopSpace;
                        continue;
                    }

                    tabView.TabItems[index].TranslationY = 0;
                }
            }
        }
    }
}

