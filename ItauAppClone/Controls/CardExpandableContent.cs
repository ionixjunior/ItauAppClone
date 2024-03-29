﻿using System.Collections.Generic;
using Xamarin.Forms;

namespace ItauAppClone.Controls
{
    public class CardExpandableContent : Frame
    {
        public CardExpandableContent(
            string headerTitle,
            LineBreakMode headerTitleTruncation,
            FontAttributes headerFontAttributes,
            NamedSize headerTitleSize,
            bool hasGradientAtTop,
            Color textColor,
            string arrowIconName,
            View headerExpandableContent,
            IList<View> footerContent)
        {
            var expandableContent = new ExpandableContent(
                headerTitle,
                headerTitleTruncation,
                headerFontAttributes,
                headerTitleSize,
                hasGradientAtTop,
                textColor,
                arrowIconName,
                headerExpandableContent
            );

            Initialize(expandableContent, footerContent);
        }

        public CardExpandableContent(
            string headerTitle,
            LineBreakMode headerTitleTruncation,
            FontAttributes headerFontAttributes,
            NamedSize headerTitleSize,
            bool hasGradientAtTop,
            Color textColor,
            string arrowIconName,
            View headerSubtitleView,
            View headerExpandableContent,
            IList<View> footerContent)
        {
            var expandableContent = new ExpandableContent(
                headerTitle,
                headerTitleTruncation,
                headerFontAttributes,
                headerTitleSize,
                hasGradientAtTop,
                textColor,
                arrowIconName,
                headerSubtitleView,
                headerExpandableContent
            );

            Initialize(expandableContent, footerContent);
        }

        private void Initialize(ExpandableContent expandableContent, IList<View> footerContent)
        {
            HasShadow = false;
            CornerRadius = 5;
            Margin = 20;
            Padding = 0;
            IsClippedToBounds = true;

            var flexLayout = new FlexLayout
            {
                Direction = FlexDirection.Column,
                Children =
                {
                    expandableContent
                }
            };

            foreach (var footerItem in footerContent)
                flexLayout.Children.Add(footerItem);

            Content = flexLayout;
        }
    }
}
