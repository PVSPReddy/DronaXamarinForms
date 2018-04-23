using System;
using Effects.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly : ResolutionGroupName("EffectsTesting")]
[assembly : ExportEffect(typeof(FocusEffect), "FocusEffect")]
namespace Effects.iOS
{
    public class FocusEffect : PlatformEffect
    {
        public FocusEffect(){}


        UIColor backgroundColor;
        protected override void OnAttached()
        {
            try
            {
                Control.BackgroundColor = backgroundColor = UIColor.FromRGB(204, 153, 255);
            }
            catch(Exception ex)
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
                    if (Control.BackgroundColor == backgroundColor)
                    {
                        Control.BackgroundColor = UIColor.White;
                    }
                    else
                    {
                        Control.BackgroundColor = backgroundColor;
                    }
                }
                else if(args.PropertyName == "Clicked")
                {
                    if (Control.BackgroundColor == backgroundColor)
                    {
                        Control.BackgroundColor = UIColor.White;
                    }
                    else
                    {
                        Control.BackgroundColor = backgroundColor;
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }
    }
}

