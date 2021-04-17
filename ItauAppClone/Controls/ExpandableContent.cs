using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ItauAppClone.Controls
{
    public class ExpandableContentBuilder
    {
        private ExpandableContent _content = new ExpandableContent();

        public ExpandableContentBuilder AddHeaderTitle(string headerTitle)
        {
            _content.SetHeaderTitle(headerTitle);
            return this;
        }

        public ExpandableContentBuilder AddHeaderTitleTruncation(LineBreakMode headerTitleTruncation)
        {
            _content._headerTitleTruncation = headerTitleTruncation;
            return this;
        }

        public ExpandableContentBuilder AddTextColor(Color textColor)
        {
            _content._textColor = textColor;
            return this;
        }

        public ExpandableContentBuilder AddArrowIconName(string arrowIconName)
        {
            _content._arrowIconName = arrowIconName;
            return this;
        }

        public ExpandableContentBuilder AddContent(View content)
        {
            _content._content = content;
            return this;
        }

        public ExpandableContentBuilder AddHeaderSubtitleView(View headerSubtitleView)
        {
            _content._headerSubtitleView = headerSubtitleView;
            return this;
        }

        public ExpandableContent Build()
        {
            _content.Build();
            return _content;
        }
    }

    public class ExpandableContent : Expander
    {
        public string _headerTitle;
        public LineBreakMode _headerTitleTruncation;
        public Color _textColor;
        public string _arrowIconName;
        public View _content;
        public Label _expanderText;
        private Image _expanderArrowImage;
        public View _headerSubtitleView;
        private const double _imageRotateExpanded = 0;
        private const double _imageRotateNotExpanded = 180;
        private const string _textExpanded = "ocultar";
        private const string _textNotExpanded = "expandir";

        public ExpandableContent() { }

        public void Build()
        {
            _expanderText = GetHeaderText();
            _expanderArrowImage = GetHeaderImage();

            Tapped += OnExpanderTapped;

            Header = GetHeader();
            Content = _content;
        }

        public ExpandableContent(
            string headerTitle,
            LineBreakMode headerTitleTruncation,
            Color textColor,
            string arrowIconName,
            View content)
        {
            Initialize(
                headerTitle,
                headerTitleTruncation,
                textColor,
                arrowIconName,
                content
            );
        }

        public ExpandableContent(
            string headerTitle,
            LineBreakMode headerTitleTruncation,
            Color textColor,
            string arrowIconName,
            View headerSubtitleView,
            View content) : this(
                headerTitle,
                headerTitleTruncation,
                textColor,
                arrowIconName,
                content)
        {
            _headerSubtitleView = headerSubtitleView;

            Initialize(
                headerTitle,
                headerTitleTruncation,
                textColor,
                arrowIconName,
                content
            );
        }

        private void Initialize(
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

        private View GetHeader()
        {
            var stack = new StackLayout
            {
                Children =
                {
                    new FlexLayout
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
                    .Height(85)
                }
            };

            if (_headerSubtitleView != null)
                stack.Children.Add(_headerSubtitleView);

            return stack;
        }
    }
}
