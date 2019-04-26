using System;

using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class RoundEdgeStackLayout : StackLayout
    {
        public GradientStyle GradientDirection { get; set; }
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
        public double CornerRadius { get; set; }
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create<RoundEdgeStackLayout, double>(p => p.CornerRadius, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.CornerRadius = newvalue;
        });
        public CornerRadiusReference CornerWRT { get; set; }
        public bool HasBorderColor { get; set; }
        public Color BorderColor { get; set; }

        public RoundEdgeStackLayout(){}
    }

    public enum GradientStyle
    {
        None = 0,
        Horizontal = 1,
        Vertical = 2,
        Inclined = 3,
    }

    public enum CornerRadiusReference
    {
        WRTHeightRequest,
        WRTWidthRequest
        //None = 0,
        //Horizontal = 1,
        //Vertical = 2,
        //Inclined = 3,
    }
}

