using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;

namespace ItauAppClone.Controls
{
    public class Shortcut : Frame
    {
        public Shortcut(string icon, string text, Color backgroundColor, Color textColor)
        {
            BackgroundColor = backgroundColor;
            HasShadow = false;
            CornerRadius = 10;

            this.Padding(0)
                .Margins(10, 0)
                .Height(120)
                .Width(120);

            Content = new StackLayout
            {
                Margin = 5,
                Children =
                {
                    new Image
                    {
                        Source = icon
                    }
                    .Height(24)
                    .Width(24),

                    new Label
                    {
                        Text = text,
                        TextColor = textColor
                    }
                    .TextCenterHorizontal()
                    .FontSize(Device.GetNamedSize(NamedSize.Small, typeof(Label))),
                }
            }
            .CenterVertical();
        }
    }
}
