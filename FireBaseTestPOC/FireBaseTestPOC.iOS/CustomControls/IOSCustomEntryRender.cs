using System;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.iOS.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(IOSCustomEntryRender))]
namespace FireBaseTestPOC.iOS.CustomControls
{
    public class IOSCustomEntryRender : EntryRenderer
    {
        public IOSCustomEntryRender(){}

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
                    Control.TextColor = element.TextColor.ToUIColor();
                    Control.TintColor = element.PlaceholderColor.ToUIColor();//for place holder
                    Control.Layer.BorderWidth = 1f;
                    //var entry1 = new Entry();
                    //Control.Layer.BorderColor = Color.FromHex("#0000").ToCGColor();
                    //Control.Layer.BorderWidth = 0;
                    //entry1.Layer.BorderWidth = 1f;



                    //to set margin on the leftside of the entry
                    if (element.IsRequiredMargin == true)
                    {
                        Control.LeftViewMode = UITextFieldViewMode.Always;
                        Control.LeftView = new UIView(new CGRect(0, 0, 15, 0));
                        Control.LeftViewMode = UITextFieldViewMode.Always;
                        Control.RightView = new UIView(new CGRect(0, 0, 15, 0));
                        Control.RightViewMode = UITextFieldViewMode.Always;
                    }
                    else
                    {

                    }


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
                    else
                    {
                        Control.Layer.BorderColor = Color.Transparent.ToCGColor();
                    }


                    //if (element.CustomFontFamily == "Avenir65")
                    //{
                    //    Control.Font = UIFont.FromName("AvenirLTStd-Medium.ttf", 20.0f);
                    //}
                    //else if (element.CustomFontFamily == "Avenir45")
                    //{
                    //    Control.Font = UIFont.FromName("AvenirLTStd-Book.ttf", 20.0f);
                    //}
                    //else
                    //{
                    //}
                    if(!(string.IsNullOrEmpty(element.CustomFontFamily)))
                    {
                        try
                        {
                            //Control.Font = UIFont.FromName(element.CustomFontFamily, element.CustomFontSize);
                            Control.Font = UIFont.FromName(element.CustomFontFamily, 20.0f);
                        }
                        catch(Exception ex)
                        {
                            var msg = ex.Message + "\n" + ex.StackTrace;
                            System.Diagnostics.Debug.WriteLine(msg);
                        }
                    }
                    //else if (!(string.IsNullOrEmpty(element.CustomFontFamily)))
                    //{
                    //    try
                    //    {
                    //        Control.Font = UIFont.FromName(element.CustomFontFamily, 20.0f);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        var msg = ex.Message + "\n" + ex.StackTrace;
                    //        System.Diagnostics.Debug.WriteLine(msg);
                    //    }
                    //}
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


                    // to set done button for phone number keyboard
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
                    // do whatever you want to the UITextField here
                    //var element = Element as CustomEntry;
                    Control.BorderStyle = UITextBorderStyle.None;
                    Control.Layer.CornerRadius = 10;
                    Control.ExclusiveTouch = true;
                    //Control.MinimumFontSize = 15f;
                    Control.AdjustsFontSizeToFitWidth = true;
                    Control.TextColor = element.TextColor.ToUIColor();
                    Control.TintColor = element.PlaceholderColor.ToUIColor();//for place holder
                    Control.Layer.BorderWidth = 1f;
                    //var entry1 = new Entry();
                    //Control.Layer.BorderColor = Color.FromHex("#0000").ToCGColor();
                    //Control.Layer.BorderWidth = 0;
                    //entry1.Layer.BorderWidth = 1f;



                    //to set margin on the leftside of the entry
                    if (element.IsRequiredMargin == true)
                    {
                        Control.LeftViewMode = UITextFieldViewMode.Always;
                        Control.LeftView = new UIView(new CGRect(0, 0, 15, 0));
                        Control.LeftViewMode = UITextFieldViewMode.Always;
                        Control.RightView = new UIView(new CGRect(0, 0, 15, 0));
                        Control.RightViewMode = UITextFieldViewMode.Always;
                    }
                    else
                    {

                    }

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


                    //if (element.CustomFontFamily == "Avenir65")
                    //{
                    //    Control.Font = UIFont.FromName("AvenirLTStd-Medium.ttf", 20.0f);
                    //}
                    //else if (element.CustomFontFamily == "Avenir45")
                    //{
                    //    Control.Font = UIFont.FromName("AvenirLTStd-Book.ttf", 20.0f);
                    //}
                    //else
                    //{
                    //}
                    if (!(string.IsNullOrEmpty(element.CustomFontFamily)))
                    {
                        try
                        {
                            //Control.Font = UIFont.FromName(element.CustomFontFamily, element.CustomFontSize);
                            Control.Font = UIFont.FromName(element.CustomFontFamily, 20.0f);
                        }
                        catch (Exception ex)
                        {
                            var msg = ex.Message + "\n" + ex.StackTrace;
                            System.Diagnostics.Debug.WriteLine(msg);
                        }
                    }
                    //else if (!(string.IsNullOrEmpty(element.CustomFontFamily)))
                    //{
                    //    try
                    //    {
                    //        Control.Font = UIFont.FromName(element.CustomFontFamily, 20.0f);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        var msg = ex.Message + "\n" + ex.StackTrace;
                    //        System.Diagnostics.Debug.WriteLine(msg);
                    //    }
                    //}
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


                    // to set done button for phone number keyboard
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

