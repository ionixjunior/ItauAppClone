using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.Controls
{
    public class ExpandableContent : Expander
    {
        private string _headerTitle;
        private LineBreakMode _headerTitleTruncation;
        private FontAttributes _headerFontAttributes;
        private NamedSize _headerTitleSize;
        private bool _hasGradientAtTop;
        private Color _textColor;
        private string _arrowIconName;
        private Label _expanderText;
        private Image _expanderArrowImage;
        private View _headerSubtitleView;
        private const double _imageRotateExpanded = 0;
        private const double _imageRotateNotExpanded = 180;
        private const string _textExpanded = "ocultar";
        private const string _textNotExpanded = "expandir";

        public ExpandableContent(
            string headerTitle,
            LineBreakMode headerTitleTruncation,
            FontAttributes headerFontAttributes,
            NamedSize headerTitleSize,
            bool hasGradientAtTop,
            Color textColor,
            string arrowIconName,
            View content)
        {
            Initialize(
                headerTitle,
                headerTitleTruncation,
                headerFontAttributes,
                headerTitleSize,
                hasGradientAtTop,
                textColor,
                arrowIconName,
                content
            );
        }

        public ExpandableContent(
            string headerTitle,
            LineBreakMode headerTitleTruncation,
            FontAttributes headerFontAttributes,
            NamedSize headerTitleSize,
            bool hasGradientAtTop,
            Color textColor,
            string arrowIconName,
            View headerSubtitleView,
            View content) : this(
                headerTitle,
                headerTitleTruncation,
                headerFontAttributes,
                headerTitleSize,
                hasGradientAtTop,
                textColor,
                arrowIconName,
                content)
        {
            _headerSubtitleView = headerSubtitleView;

            Initialize(
                headerTitle,
                headerTitleTruncation,
                headerFontAttributes,
                headerTitleSize,
                hasGradientAtTop,
                textColor,
                arrowIconName,
                content
            );
        }

        private void Initialize(
            string headerTitle,
            LineBreakMode headerTitleTruncation,
            FontAttributes headerFontAttributes,
            NamedSize headerTitleSize,
            bool hasGradientAtTop,
            Color textColor,
            string arrowIconName,
            View content)
        {
            _headerTitle = headerTitle;
            _headerTitleTruncation = headerTitleTruncation;
            _headerFontAttributes = headerFontAttributes;
            _headerTitleSize = headerTitleSize;
            _hasGradientAtTop = hasGradientAtTop;
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

        private enum GridHeaderColumn { Left, Right };

        private View GetHeader()
        {
            var stack = new StackLayout
            {
                Children =
                {
                    new BoxView
                    {
                        IsVisible = _hasGradientAtTop,
                        Background = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(1, 1),
                            GradientStops = new GradientStopCollection
                            {
                                new GradientStop
                                {
                                    Color = Color.FromHex("#9E9176"),
                                    Offset = 0.0f
                                },
                                new GradientStop
                                {
                                    Color = Color.FromHex("#DED3B5"),
                                    Offset = 1.0f
                                }
                            }
                        },
                        HeightRequest = 10
                    },

                    new Grid
                    {
                        ColumnSpacing = 10,
                        ColumnDefinitions = Columns.Define(
                            (GridHeaderColumn.Left, Star),
                            (GridHeaderColumn.Right, Auto)
                        ),

                        Children =
                        {
                            new StackLayout
                            {
                                Children =
                                {
                                    new Label
                                    {
                                        Text = _headerTitle,
                                        TextColor = _textColor,
                                        LineBreakMode = _headerTitleTruncation,
                                        FontAttributes = _headerFontAttributes
                                    }
                                    .FontSize(Device.GetNamedSize(_headerTitleSize, typeof(Label)))
                                }
                            }
                            .Column(GridHeaderColumn.Left),

                            new StackLayout
                            {
                                VerticalOptions = LayoutOptions.Start,
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    _expanderText,
                                    _expanderArrowImage
                                }
                            }
                            .Column(GridHeaderColumn.Right)
                            .Margins(0, 10, 0, 0)
                        }
                    }
                    .Margin(20, 20)
                }
            };

            if (_headerSubtitleView != null)
            {
                stack.Children.Add(_headerSubtitleView);
            }

            return stack;
        }
    }
}
