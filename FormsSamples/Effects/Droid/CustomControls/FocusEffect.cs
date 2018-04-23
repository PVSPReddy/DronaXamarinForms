using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("EffectsTesting")]
[assembly: ExportEffect(typeof(FocusEffect), "FocusEffect")]
namespace Effects.Droid
{
    public class FocusEffect : PlatformEffect
    {
        public FocusEffect(){}

        Android.Graphics.Color backgroundColor;
        protected override void OnAttached()
        {
            try
            {
                backgroundColor = Android.Graphics.Color.LightGreen;
                Control.SetBackgroundColor(backgroundColor);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        protected override void OnDetached()
        {
            try
            {

            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == backgroundColor)
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.Black);
                    }
                    else
                    {
                        Control.SetBackgroundColor(backgroundColor);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }
    }
}

