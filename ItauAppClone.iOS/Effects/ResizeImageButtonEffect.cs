using System;
using ItauAppClone.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("AppClone")]
[assembly: ExportEffect(typeof(ResizeImageButtonEffect), nameof(ResizeImageButtonEffect))]
namespace ItauAppClone.iOS.Effects
{
    public class ResizeImageButtonEffect : PlatformEffect
    {
        private UIEdgeInsets _defaultImageEdgeInsets;

        protected override void OnAttached()
        {
            if (Control is UIButton button)
            {
                _defaultImageEdgeInsets = button.ImageEdgeInsets;
                button.ImageEdgeInsets = new UIEdgeInsets(4, 4, 4, 4);
            }
        }

        protected override void OnDetached()
        {
            if (Control is UIButton button)
            {
                button.ImageEdgeInsets = _defaultImageEdgeInsets;
            }
        }
    }
}
