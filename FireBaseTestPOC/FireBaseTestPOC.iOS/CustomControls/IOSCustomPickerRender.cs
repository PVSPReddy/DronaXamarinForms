using System;
using System.ComponentModel;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.iOS.CustomControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(IOSCustomPickerRender))]
namespace FireBaseTestPOC.iOS.CustomControls
{
    public class IOSCustomPickerRender : PickerRenderer
    {
        public IOSCustomPickerRender(){}
        CustomPicker element;

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            try
            {
                element = Element as CustomPicker;
                if (e.NewElement != null)
                {
                    element = Element as CustomPicker;
                }
                else
                {
                    element = e.OldElement as CustomPicker;
                }
                UpdateElementWithChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            try
            {
                element = Element as CustomPicker;
                System.Diagnostics.Debug.WriteLine("Current Page is " + this.GetType().ToString() + " : " + e.PropertyName);
                UpdateElementWithChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        protected void UpdateElementWithChanges()
        {
            try
            {
                if (element != null)
                {
                    if (Control != null)
                    {
                        var textGiven = element.EnterText;
                        Control.BorderStyle = UITextBorderStyle.None;
                        Control.Layer.CornerRadius = 10;
                        Control.ExclusiveTouch = true;

                        if (!string.IsNullOrWhiteSpace(textGiven))
                        {
                            Control.Text = textGiven;
                        }
                        Control.TextColor = UIColor.Black;
                        Control.AdjustsFontSizeToFitWidth = true;
                        Control.TintColor = UIColor.Black;
                        Control.AttributedPlaceholder = new Foundation.NSAttributedString(Control.AttributedPlaceholder.Value, foregroundColor: UIColor.Black);
                        if (!(string.IsNullOrEmpty(element.FontFamily)))
                        {
                            try
                            {
                                Control.Font = UIFont.FromName(element.FontFamily, 20.0f);
                            }
                            catch (Exception ex)
                            {
                                var msg = ex.Message + "\n" + ex.StackTrace;
                                System.Diagnostics.Debug.WriteLine(msg);
                            }
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
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
}