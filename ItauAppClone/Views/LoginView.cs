using System;

using Xamarin.Forms;

namespace ItauAppClone.Views
{
    public class LoginView : ContentPage
    {
        public LoginView()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage", FontSize = 40 }
                }
            };
        }
    }
}

