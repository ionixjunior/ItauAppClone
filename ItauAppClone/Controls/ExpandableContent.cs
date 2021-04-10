using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ItauAppClone.Controls
{
    public class ExpandableContent : Expander
    {
        private string _headerTitle;
        private LineBreakMode _headerTitleTruncation;
        private Color _textColor;
        private string _arrowIconName;
        private Label _expanderText;
        private Image _expanderArrowImage;
        private const double _imageRotateExpanded = 0;
        private const double _imageRotateNotExpanded = 180;
        private const string _textExpanded = "ocultar";
        private const string _textNotExpanded = "expandir";

        public ExpandableContent(
            string headerTitle,
            LineBreakMode headerTitleTruncation,
            Color textColor,
            string arrowIconName,
            View content)
        {
            _headerTitle = headerTitle;
            _headerTitleTruncation = headerTitleTruncation;
            _textColor = textColor;
            _arrowIconName = arrowIconName;
            _expanderText = GetHeaderText();
            _expanderArrowImage = GetHeaderImage();

            Tapped += OnExpanderTapped;

            Header = GetHeader();
            Content = content;
        }

        private Label GetHeaderText()
        {
            return new Label
            {
                Text = _textNotExpanded,
                TextColor = _textColor
            };
        }

        private Image GetHeaderImage()
        {
            return new Image
            {
                Source = _arrowIconName,
                Rotation = _imageRotateNotExpanded
            }
            .Margins(6, 0, 0, 0)
            .Height(12)
            .Width(12);
        }

        private void OnExpanderTapped(object sender, EventArgs _)
        {
            if (sender is Expander expander)
            {
                _expanderText.Text = expander.IsExpanded ? _textExpanded : _textNotExpanded;
                _expanderArrowImage.Rotation = expander.IsExpanded ? _imageRotateExpanded : _imageRotateNotExpanded;
            }
        }

        private FlexLayout GetHeader()
        {
            return new FlexLayout
            {
                JustifyContent = FlexJustify.SpaceBetween,
                AlignItems = FlexAlignItems.Start,
                Children =
                {
                    new FlexLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = _headerTitle,
                                TextColor = _textColor,
                                LineBreakMode = _headerTitleTruncation
                            }
                            .FontSize(Device.GetNamedSize(NamedSize.Title, typeof(Label)))
                        }
                    }
                    .Grow(2),

                    new FlexLayout
                    {
                        JustifyContent = FlexJustify.End,
                        AlignItems = FlexAlignItems.Start,
                        Children =
                        {
                            _expanderText,
                            _expanderArrowImage
                        }
                    }
                    .Margins(0, 10, 0, 0)
                    .Grow(1)
                }
            }
            .Height(85);
        }
    }
}
