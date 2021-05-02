using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace ItauAppClone.Controls
{
    public class CardInfoContent : Frame
    {
        enum GridColumn { Left, Right }

        public CardInfoContent(string icon, string text)
        {
            BackgroundColor = Color.FromHex("#0D6EB0");
            HasShadow = false;
            CornerRadius = 5;
            Margin = new Thickness(20);

            Content = new Grid
            {
                ColumnDefinitions = Columns.Define(
                    (GridColumn.Left, 40),
                    (GridColumn.Right, Star)
                ),

                ColumnSpacing = 20,

                Children =
                {
                    new Image
                    {
                        Source = icon
                    }
                    .Column(GridColumn.Left),

                    new Label
                    {
                        Text = text,
                        TextColor = Color.White,
                        FontAttributes = FontAttributes.Bold
                    }
                    .Column(GridColumn.Right)
                    .FontSize(Device.GetNamedSize(NamedSize.Large, typeof(Label)))
                }
            };
        }
    }
}
