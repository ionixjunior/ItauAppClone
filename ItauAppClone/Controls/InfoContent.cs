using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.Controls
{
    public class InfoContent : Grid
    {
        enum GridColumn { Left, Right }

        public InfoContent(string icon, string text)
        {
            ColumnDefinitions = Columns.Define(
                (GridColumn.Left, 40),
                (GridColumn.Right, Star)
            );
            ColumnSpacing = 20;

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
                    FontAttributes = FontAttributes.Bold
                }
                .Column(GridColumn.Right)
                .FontSize(Device.GetNamedSize(NamedSize.Large, typeof(Label)))
            );
        }
    }
}
