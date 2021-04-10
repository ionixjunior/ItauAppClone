using System.Collections.Generic;
using Xamarin.Forms;

namespace ItauAppClone.Controls
{
    public class CardExpandableContent : Frame
    {
        public CardExpandableContent(
            string headerTitle,
            LineBreakMode headerTitleTruncation,
            Color textColor,
            string arrowIconName,
            View headerExpandableContent,
            IList<View> footerContent)
        {
            HasShadow = false;
            CornerRadius = 5;
            Margin = 20;

            var flexLayout = new FlexLayout
            {
                Direction = FlexDirection.Column,
                Children =
                {
                    new ExpandableContent(
                        headerTitle,
                        headerTitleTruncation,
                        textColor,
                        arrowIconName,
                        headerExpandableContent
                    )
                }
            };

            foreach (var footerItem in footerContent)
                flexLayout.Children.Add(footerItem);

            Content = flexLayout;
        }
    }
}
