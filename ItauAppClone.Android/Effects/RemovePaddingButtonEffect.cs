using System;
using ItauAppClone.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("AppClone")]
[assembly: ExportEffect(typeof(RemovePaddingButtonEffect), nameof(RemovePaddingButtonEffect))]
namespace ItauAppClone.Droid.Effects
{
    public class RemovePaddingButtonEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (Control is Android.Widget.Button button)
                {
                    button.SetMinWidth(0);
                    button.SetPadding(0, button.PaddingTop, 0, button.PaddingBottom);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }

        protected override void OnDetached()
        {
            
        }
    }
}
