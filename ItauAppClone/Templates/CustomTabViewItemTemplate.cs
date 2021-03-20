﻿using System;
using Xamarin.CommunityToolkit.Converters;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ItauAppClone.Templates
{
    public class CustomTabViewItemTemplate : Grid
	{
		readonly Image icon;
		readonly Label text;
		readonly TabBadgeView badge;

		public CustomTabViewItemTemplate()
		{
			RowSpacing = 0;

			HorizontalOptions = LayoutOptions.FillAndExpand;
			VerticalOptions = LayoutOptions.FillAndExpand;

			RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
			RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

			icon = new Image
			{
				Aspect = Aspect.AspectFit,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Margin = new Thickness(0, 6)
			};

			text = new Label
			{
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Margin = new Thickness(0, 6)
			};

			badge = new TabBadgeView
			{
				PlacementTarget = icon,
				Margin = new Thickness(0)
			};

			Children.Add(icon);
			Children.Add(text);
			Children.Add(badge);

			SetRow(icon, 0);
			SetRow(text, 1);
			SetRow(badge, 0);
			SetRowSpan(badge, 2);
		}

		protected override void OnParentSet()
		{
			base.OnParentSet();

			BindingContext = Parent;

			icon.SetBinding(Image.SourceProperty, "CurrentIcon");

			text.SetBinding(Label.TextProperty, "Text", BindingMode.OneWay, new TextCaseConverter { Type = TextCaseType.Upper });
			text.SetBinding(Label.TextColorProperty, "CurrentTextColor");
			text.SetBinding(Label.FontSizeProperty, "CurrentFontSize");
			text.SetBinding(Label.FontAttributesProperty, "CurrentFontAttributes");
			text.SetBinding(Label.FontFamilyProperty, "CurrentFontFamily");

			badge.SetBinding(TabBadgeView.BackgroundColorProperty, "CurrentBadgeBackgroundColor");
			badge.SetBinding(TabBadgeView.TextProperty, "BadgeText");
			badge.SetBinding(TabBadgeView.TextColorProperty, "BadgeTextColor");
		}

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);

			UpdateLayout();
			UpdateBadgePosition();
		}

		void UpdateLayout()
		{
			if (!(BindingContext is TabViewItem tabViewItem))
				return;

			if (tabViewItem.CurrentIcon == null)
			{
				SetRow(text, 0);
				SetRowSpan(text, 2);
			}
			else
			{
				SetRow(text, 1);
				SetRowSpan(text, 1);
			}
		}

		void UpdateBadgePosition()
		{
			if (badge == null)
				return;

			var translationX = Math.Max(icon.Width, text.Width);

			if (translationX > 0 && badge.TranslationX == 0)
				badge.TranslationX = translationX / 2;

			if (badge.TranslationY == 0)
				badge.TranslationY = 2;
		}
	}
}
