using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.Controls
{
    public class InfoContent : Grid
    {
        enum GridColumn { Left, Middle, Right }

        public InfoContent(string icon, string text, bool hasArrowIcon = false, bool hasTruncateText = false)
        {
            ColumnDefinitions = Columns.Define(
                (GridColumn.Left, 40),
                (GridColumn.Middle, Star),
                (GridColumn.Right, Auto)
            );
            ColumnSpacing = 0;

            Children.Add(
                new Image
                {
                    Source = icon
                }
                .Column(GridColumn.Left)
            );

            Children.Add(GetText(text, hasTruncateText));

            if (hasArrowIcon)
            {
                Children.Add(
                    new Image
                    {
                        Source = "arrow_white_item"
                    }
                    .Height(30)
                    .Column(GridColumn.Right)
                    .Margins(20, 0, 0, 0)
                );
            }
        }

        private Label GetText(string text, bool hasTruncateText)
        {
            var label = new Label
            {
                Text = text,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold
            }
            .Column(GridColumn.Middle)
            .FontSize(Device.GetNamedSize(NamedSize.Large, typeof(Label)))
            .Margins(20, 0, 0, 0);

            if (hasTruncateText)
            {
                label.MaxLines = 2;
                label.LineBreakMode = LineBreakMode.TailTruncation;
            }

            return label;
        }
    }
}
