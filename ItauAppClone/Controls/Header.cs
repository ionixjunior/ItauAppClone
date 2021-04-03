using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;

namespace ItauAppClone.Controls
{
    public class Header : FlexLayout
    {
        public Header()
        {
            BackgroundColor = Color.White;
            AlignItems = FlexAlignItems.Center;
            Padding = new Thickness(10);

            Children.Add(GetAvatar());
            Children.Add(GetAccountInfo());
            Children.Add(GetBellIcon());
            Children.Add(GetSearchIcon());
        }

        private Frame GetAvatar()
        {
            return new Frame
            {
                BackgroundColor = Color.FromHex("#EEE9E3"),
                HeightRequest = 40,
                WidthRequest = 40,
                CornerRadius = 20,
                HasShadow = false,
                BorderColor = Color.FromHex("#DDD9D9"),
                Content = new Label
                {
                    Text = "MS",
                    TextColor = AppStyle.PrimaryColor,
                }
                .TextCenterVertical()
                .TextCenterHorizontal()
                .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            }
            .Padding(0)
            .Margin(10, 0);
        }

        private StackLayout GetAccountInfo()
        {
            return new StackLayout
            {
                Spacing = 0,
                Children =
                {
                    new Label
                    {
                        Text = "olá, Marcos",
                        TextColor = AppStyle.PrimaryColor,
                        FontAttributes = FontAttributes.Bold
                    }
                    .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Label))),

                    new Label { Text = "ag **47 c/c/ ***79-7", TextColor = AppStyle.TextColor }
                }
            }
            .Margin(10, 0)
            .Grow(1);
        }

        private static Image GetBellIcon()
        {
            return new Image
            {
                Source = "bell"
            }
            .Margin(10, 0)
            .Height(24)
            .Width(24);
        }

        private static Image GetSearchIcon()
        {
            return new Image
            {
                Source = "search_outlined"
            }
            .Margin(10, 0)
            .Height(24)
            .Width(24);
        }
    }
}

