using System;
using BehaviorsAndTriggers.iOS;
using BehaviorsAndTriggers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace BehaviorsAndTriggers.iOS
{
	public class CustomEntryRenderer : EntryRenderer
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

				if (Control != null)
				{
					// do whatever you want to the UITextField here
					//var element = Element as CustomEntry;
					Control.BorderStyle = UITextBorderStyle.None;
					Control.Layer.CornerRadius = 10;
					Control.ExclusiveTouch = true;
					//Control.MinimumFontSize = 15f;
					Control.AdjustsFontSizeToFitWidth = true;
                    //Control.font
                    //Control.TextColor = UIColor.White;
                    var fSize = (element.FontSize == 0 ) ?  20.0f : ((nfloat)(element.FontSize));

                    /*
                    UIFont uiFontValue = UIFont.FromName("Montserrat-Regular", fSize);
					if (element.CustomFontFamily == "MontserratBold")
                    {
                        uiFontValue = UIFont.FromName("Montserrat-Bold",fSize);
                    }
                    else if (element.CustomFontFamily == "MontserratLight")
                    {
                        Control.Font = UIFont.FromName("Montserrat-Light", fSize);
                    }
                    else
                    {
                        //Control.Font = UIFont.FromName("Montserrat-Regular", fSize);
                    }
                    Control.Font = uiFontValue;

                    Control.AttributedPlaceholder = new Foundation.NSAttributedString(element.Placeholder, uiFontValue, element.PlaceholderColor.ToUIColor());
                    */


                    /*
					if (element.CustomFontSize != 0)
					{
						UIFont font = Control.Font.WithSize(element.CustomFontSize);
						Control.Font = font;
					}
					else
					{
					}
                    */
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
				if (Control != null)
				{
					// do whatever you want to the UITextField here
					//var element = Element as CustomEntry;
					Control.BorderStyle = UITextBorderStyle.None;
					Control.Layer.CornerRadius = 10;
					Control.ExclusiveTouch = true;
					//Control.MinimumFontSize = 15f;
					Control.AdjustsFontSizeToFitWidth = true;
					//Control.TextColor = UIColor.White;//for place holder
					//var entry1 = new Entry();
					//Control.Layer.BorderColor = Color.FromHex("#0000").ToCGColor();
					//Control.Layer.BorderWidth = 0;
					//entry1.Layer.BorderWidth = 1f;
                    var fSize = (element.FontSize == 0) ? 20.0f : ((nfloat)(element.FontSize));

                    /*
                    UIFont uiFontValue = UIFont.FromName("Montserrat-Regular", fSize);
                    if (element.CustomFontFamily == "MontserratBold")
                    {
                        uiFontValue = UIFont.FromName("Montserrat-Bold", fSize);
                    }
                    else if (element.CustomFontFamily == "MontserratLight")
                    {
                        Control.Font = UIFont.FromName("Montserrat-Light", fSize);
                    }
                    else
                    {
                        Control.Font = UIFont.FromName("Montserrat-Regular", fSize);
                    }
                    Control.Font = uiFontValue;

                    Control.AttributedPlaceholder = new Foundation.NSAttributedString(element.Placeholder, uiFontValue, element.PlaceholderColor.ToUIColor());
                    */


                    /*
					if (element.CustomFontSize != 0)
					{
						UIFont font = Control.Font.WithSize(element.CustomFontSize);
						Control.Font = font;
					}
					else
					{
					}
					*/
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}
}