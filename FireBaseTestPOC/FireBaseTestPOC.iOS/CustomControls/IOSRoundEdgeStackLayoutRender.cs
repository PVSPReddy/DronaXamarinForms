using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.iOS.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundEdgeStackLayout), typeof(IOSRoundEdgeStackLayoutRender))]
namespace FireBaseTestPOC.iOS.CustomControls
{
    public class IOSRoundEdgeStackLayoutRender : VisualElementRenderer<StackLayout>
    {
        public IOSRoundEdgeStackLayoutRender(){}

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            System.Diagnostics.Debug.WriteLine("Current Page is " + this.GetType().ToString() + " : " + e.PropertyName);
            UpdateElement(this.Frame);
        }

        protected void UpdateElement(CoreGraphics.CGRect rect)
        {
            RoundEdgeStackLayout stack = (RoundEdgeStackLayout)this.Element;
            CGColor startColor = stack.StartColor.ToCGColor();
            CGColor endColor = stack.EndColor.ToCGColor();

            try
            {
                //if(stack.HasBorderColor == true)
                //{

                //}
                //else if(stack.BorderColor != null)
                //{

                //}
                if (stack.HasBorderColor == true && stack.BorderColor.ToCGColor() != null)
                {
                    double min = Math.Min(Element.Width, Element.Height);
                    this.Layer.CornerRadius = (float)(min / 2.0);
                    this.Layer.MasksToBounds = false;
                    this.Layer.BorderColor = stack.BorderColor.ToCGColor();
                    this.Layer.BorderWidth = Convert.ToSingle(stack.BorderThickness);
                    this.ClipsToBounds = true;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                //Debug.WriteLine("Unable to create circle image: " + ex);
            }

            var gradientLayer = new CAGradientLayer();
            GradientStyle gradientStyle = stack.GradientDirection;
            if (gradientStyle != GradientStyle.None)
            {
                if (gradientStyle == GradientStyle.Vertical)
                {

                }
                else if (gradientStyle == GradientStyle.Horizontal)
                {
                    gradientLayer.StartPoint = new CGPoint(0, 0.5);
                    gradientLayer.EndPoint = new CGPoint(1, 0.5);
                }
                else if (gradientStyle == GradientStyle.Inclined)
                {
                    gradientLayer.StartPoint = new CGPoint(0, 0.5);
                    gradientLayer.EndPoint = new CGPoint(1, 0.5);
                }
                else
                {

                }
            }

            nfloat cornerRadius = 0.0f;
            try
            {
                if (stack.CornerWRT == CornerRadiusReference.WRTHeightRequest && stack.CornerRadius == 0)
                {
                    cornerRadius = (float)(stack.HeightRequest / 2);
                }
                else if (stack.CornerWRT == CornerRadiusReference.WRTWidthRequest && stack.CornerRadius == 0)
                {
                    cornerRadius = (float)(stack.WidthRequest / 2);
                }
                else
                {
                    cornerRadius = (float)(stack.CornerRadius);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            gradientLayer.Frame = rect;
            gradientLayer.Colors = new CGColor[] { startColor, endColor };
            gradientLayer.ModelLayer.CornerRadius = cornerRadius;//(float)(stack.CornerRadius);
            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }

        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);
            UpdateElement(rect);
        }
    }
}