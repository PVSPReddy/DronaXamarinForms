using System;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Text.Method;
using Android.Util;
using FMS.Android;
using FMS;
using FMS.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Graphicss = Android.Graphics;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRender))]
namespace FMS.Android
{
	public class CustomEntryRender : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			try
			{
				CustomEntry element = Element as CustomEntry;
				if (e.NewElement != null)
				{
					element = Element as CustomEntry;
				}
				else
				{
					element = e.OldElement as CustomEntry;
				}
				if (element.IsCustomPassword == true)
				{
					Control.TransformationMethod = PasswordTransformationMethod.Instance;
				}
				if (Control != null)
				{
					GradientDrawable gradientDrawable = new GradientDrawable();
					gradientDrawable.SetColor(global::Android.Graphics.Color.Transparent);
					gradientDrawable.SetStroke(2, global::Android.Graphics.Color.ParseColor(element.BorderColors));
					this.Control.SetBackgroundDrawable(gradientDrawable);
					this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
					if (element.CustomFontSize != 0.0)
					{
						Control.SetTextSize(ComplexUnitType.Dip, element.CustomFontSize);
					}
					if (element.CustomFontFamily == "Avenir65")
					{
						Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Medium.ttf");
						Control.Typeface = font;
					}
					else if (element.CustomFontFamily == "Avenir45")
					{
						Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Book.ttf");
						Control.Typeface = font;
					}
					else
					{
					}

					if (element.IsPhoneNumber == true)
					{
						Control.SetRawInputType(global::Android.Text.InputTypes.ClassPhone);
					}
					else if (element.IsNumeric == true)
					{
						Control.SetRawInputType(global::Android.Text.InputTypes.ClassNumber);
					}
					else if (element.IsEmail == true)
					{
						Control.SetRawInputType(global::Android.Text.InputTypes.TextVariationEmailAddress);
					}
					else
					{

					}
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			try
			{
				CustomEntry element = Element as CustomEntry;

				if (element.IsCustomPassword == true)
				{
					Control.TransformationMethod = PasswordTransformationMethod.Instance;
				}
				else
				{
					Control.TransformationMethod = HideReturnsTransformationMethod.Instance; //PasswordTransformationMethod.Instance;
				}
				if (Control != null)
				{
					GradientDrawable gradientDrawable = new GradientDrawable();
					gradientDrawable.SetColor(global::Android.Graphics.Color.Transparent);
					gradientDrawable.SetStroke(2, global::Android.Graphics.Color.ParseColor(element.BorderColors));
					this.Control.SetBackgroundDrawable(gradientDrawable);
					this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
					if (element.CustomFontSize != 0.0)
					{
						Control.SetTextSize(ComplexUnitType.Dip, element.CustomFontSize);
					}
					if (element.CustomFontFamily == "Avenir65")
					{
						Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Medium.ttf");
						Control.Typeface = font;
					}
					else if (element.CustomFontFamily == "Avenir45")
					{
						Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Book.ttf");
						Control.Typeface = font;
					}
					else
					{
					}

					if (element.IsPhoneNumber == true)
					{
						Control.SetRawInputType(global::Android.Text.InputTypes.ClassPhone);
					}
					else if (element.IsNumeric == true)
					{
						Control.SetRawInputType(global::Android.Text.InputTypes.ClassNumber);
					}
					else if (element.IsEmail == true)
					{
						Control.SetRawInputType(global::Android.Text.InputTypes.TextVariationEmailAddress);
					}
					else
					{

					}
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}
}