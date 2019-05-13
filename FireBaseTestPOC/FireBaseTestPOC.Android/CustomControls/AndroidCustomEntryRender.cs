using System;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using Android.Text.Method;
using Graphicss = Android.Graphics;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(AndroidCustomEntryRender))]
namespace FireBaseTestPOC.Droid.CustomControls
{
    public class AndroidCustomEntryRender : EntryRenderer
    {
        public AndroidCustomEntryRender(){}

        CustomEntry element;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            try
            {
                element = Element as CustomEntry;
                if (e.NewElement != null)
                {
                    element = Element as CustomEntry;
                }
                else
                {
                    element = e.OldElement as CustomEntry;
                }
                UpdateElementWithChanges();
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
                element = Element as CustomEntry;
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
                        //var element = Element as CustomEntry;

                        GradientDrawable gradientDrawable = new GradientDrawable();
                        gradientDrawable.SetColor(global::Android.Graphics.Color.Transparent);
                        if (element.BorderColor != null)
                        {
                            //gradientDrawable.SetStroke(2, global::Android.Graphics.Color.ParseColor(element.BorderColor));
                            gradientDrawable.SetStroke(2, element.BorderColor.ToAndroid());
                        }
                        //gradientDrawable.SetCornerRadius(45); // increase or decrease to changes the corner look
                        this.Control.SetBackgroundDrawable(gradientDrawable);
                        this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                        //Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));//for placeholder  
                        //this.Control.InputType = InputTypes.TextVariationPassword;
                        Control.Gravity = global::Android.Views.GravityFlags.CenterVertical;
                        Control.SetPadding(30, 0, 30, 0);

                        //Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));//for placeholder  

                        /*
                        try
                        {
                            if (element.CustomFontSize != 0.0)
                            {
                                Control.SetTextSize(ComplexUnitType.Dip, element.CustomFontSize);
                            }
                            if (element.FontSize != 0)
                            {
                                Control.SetTextSize(ComplexUnitType.Dip, (float)element.FontSize);
                            }
                        }
                        catch (Exception ex)
                        {
                            var msg = ex.Message;
                        }
                        */
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
                        else if (element.IsPassword == true)
                        {
                            Control.SetPadding(30, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
                        }
                        else
                        {

                        }

                        if (element.IsPassword == true)
                        {
                            Control.TransformationMethod = PasswordTransformationMethod.Instance;
                            //Control.InputType = InputTypes.TextVariationPassword;
                            //Control.InputType = InputTypes.TextVariationPassword | InputTypes.ClassText;
                        }
                        else
                        {
                            Control.TransformationMethod = HideReturnsTransformationMethod.Instance; //PasswordTransformationMethod.Instance;
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

