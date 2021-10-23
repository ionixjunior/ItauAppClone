using System;
using ItauAppClone.Interfaces;
using Xamarin.Forms;

namespace ItauAppClone.ContentViews.Transacao
{
    public class TransacaoContentView : ContentView, IReload
    {
        public TransacaoContentView() => Build();

        public void Build()
        {
            Content = new Label { Text = "Hello ContentView" };
        }
    }
}

