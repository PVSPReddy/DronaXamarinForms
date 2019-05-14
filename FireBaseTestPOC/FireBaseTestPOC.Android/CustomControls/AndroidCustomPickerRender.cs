using System;
using System.ComponentModel;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Graphicss = Android.Graphics;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(AndroidCustomPickerRender))]
namespace FireBaseTestPOC.Droid.CustomControls
{
    public class AndroidCustomPickerRender : PickerRenderer
    {
        public AndroidCustomPickerRender() { }
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
                        GradientDrawable gd = new GradientDrawable();
                        //gd.SetCornerRadius(45); // increase or decrease to changes the corner look
                        gd.SetColor(global::Android.Graphics.Color.Transparent);
                        //gd.SetStroke(2, global::Android.Graphics.Color.Gray);
                        this.Control.SetBackgroundDrawable(gd);
                        this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                        //Control.Text = element.EnterText;
                        Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));//for placeholder
                        //this.Control.InputType = InputTypes.TextVariationPassword;
                        if (element.CustomFontSize != 0.0)
                        {
                            Control.SetTextSize(ComplexUnitType.Dip, element.CustomFontSize);
                        }
                        if (!(string.IsNullOrEmpty(element.CustomFontFamily)))
                        {
                            try
                            {
                                Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, element.CustomFontFamily);
                                Control.Typeface = font;
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