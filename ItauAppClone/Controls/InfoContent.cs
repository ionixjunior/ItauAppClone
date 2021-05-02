using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.Controls
{
    public class InfoContent : Grid
    {
        enum GridColumn { Left, Middle, Right }

        public InfoContent(string icon, string text, bool hasArrowIcon = false)
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

            Children.Add(
                new Label
                {
                    Text = text,
                    TextColor = Color.White,
                    FontAttributes = FontAttributes.Bold,
                    MaxLines = 2,
                    LineBreakMode = LineBreakMode.TailTruncation
                }
                .Column(GridColumn.Middle)
                .FontSize(Device.GetNamedSize(NamedSize.Large, typeof(Label)))
                .Margins(20, 0, 0, 0)
            );

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
    }
}
