using System;
using FMS.iOS;
using FMS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ObjCRuntime;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace FMS.iOS
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
                    Control.BorderStyle = UITextBorderStyle.Line;
                    Control.Layer.CornerRadius = 0;
                    Control.ExclusiveTouch = true;
                    Control.AdjustsFontSizeToFitWidth = true;
                    Control.TextColor = UIColor.Black; Control.TintColor = UIColor.Gray;
                    Control.Layer.BorderWidth = 1f;
                    if (element.BorderColors == "#ff0000")
                    {
                        Control.Layer.BorderColor = Color.Red.ToCGColor();
                    }
                    else if (element.BorderColors == "#6C6C6C")
                    {
                        Control.Layer.BorderColor = Color.Gray.ToCGColor();
                    }
                    else if (element.BorderColors == "#FFFFFF")
                    {
                        Control.Layer.BorderColor = Color.White.ToCGColor();
                    }

                    if (element.CustomFontFamily == "Avenir65")
                    {
                        Control.Font = UIFont.FromName("AvenirLTStd-Medium.ttf", 20.0f);
                    }
                    else if (element.CustomFontFamily == "Avenir45")
                    {
                        Control.Font = UIFont.FromName("AvenirLTStd-Book.ttf", 20.0f);
                    }
                    else
                    {
                    }
                    if (element.CustomFontSize != 0)
                    {
                        UIFont font = Control.Font.WithSize(element.CustomFontSize);
                        Control.Font = font;
                    }
                    else
                    {
                    }
                    if (element.IsPhoneNumber == true || element.IsNumeric == true)
                    {
                        var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

                        toolbar.Items = new[]
                        {
                            new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                            new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
                        };
                        this.Control.InputAccessoryView = toolbar;
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
                if (Control != null)
                {
                    Control.BorderStyle = UITextBorderStyle.Line;
                    Control.Layer.CornerRadius = 0;
                    Control.ExclusiveTouch = true;
                    Control.AdjustsFontSizeToFitWidth = false;
                    Control.TextColor = UIColor.Black; Control.TintColor = UIColor.Gray;
                    Control.Layer.BorderWidth = 1f;
                    if (element.BorderColors == "#ff0000")
                    {
                        Control.Layer.BorderColor = Color.Red.ToCGColor();
                    }
                    else if (element.BorderColors == "#6C6C6C")
                    {
                        Control.Layer.BorderColor = Color.Gray.ToCGColor();
                    }
                    else if (element.BorderColors == "#FFFFFF")
                    {
                        Control.Layer.BorderColor = Color.White.ToCGColor();
                    }

                    if (element.CustomFontFamily == "Avenir65")
                    {
                        Control.Font = UIFont.FromName("AvenirLTStd-Medium.ttf", 20.0f);
                    }
                    else if (element.CustomFontFamily == "Avenir45")
                    {
                        Control.Font = UIFont.FromName("AvenirLTStd-Book.ttf", 20.0f);
                    }
                    else
                    {
                    }
                    if (element.CustomFontSize != 0)
                    {
                        UIFont font = Control.Font.WithSize(element.CustomFontSize);
                        Control.Font = font;
                    }
                    else
                    {
                    }
                    if (element.IsPhoneNumber == true || element.IsNumeric == true)
                    {
                        var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

                        toolbar.Items = new[]
                        {
                            new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                            new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
                        };

                        this.Control.InputAccessoryView = toolbar;
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