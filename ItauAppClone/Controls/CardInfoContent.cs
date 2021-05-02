using Xamarin.Forms;

namespace ItauAppClone.Controls
{
    public class CardInfoContent : Frame
    {
        public CardInfoContent(string icon, string text, bool hasArrowIcon = false)
        {
            BackgroundColor = Color.FromHex("#0D6EB0");
            HasShadow = false;
            CornerRadius = 5;
            Margin = new Thickness(20);
            Content = new InfoContent(icon, text, hasArrowIcon);
        }
    }
}
