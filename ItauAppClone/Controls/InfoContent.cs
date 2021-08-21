using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.Controls
{
    public class InfoContent : Grid
    {
        enum GridColumn { Text, Icon }

        public InfoContent(string icon, string text, bool hasTruncateText = false)
        {
            ColumnDefinitions = Columns.Define(
                (GridColumn.Text, Star),
                (GridColumn.Icon, 60)
            );
            ColumnSpacing = 0;

            Children.Add(
                new Image
                {
                    Source = icon
                }
                .Column(GridColumn.Icon)
            );

            Children.Add(GetText(text, hasTruncateText));
        }

        private Label GetText(string text, bool hasTruncateText)
        {
            var label = new Label
            {
                Text = text,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold
            }
            .Column(GridColumn.Text)
            .FontSize(Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            .Margins(0, 0, 20, 0);

            if (hasTruncateText)
            {
                label.MaxLines = 2;
                label.LineBreakMode = LineBreakMode.TailTruncation;
            }

            return label;
        }
    }
}
