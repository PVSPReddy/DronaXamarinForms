using System;

using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class RoundEdgeStackLayout : StackLayout
    {
        public GradientStyle GradientDirection { get; set; }

        public Color StartColor { get; set; }
        public static BindableProperty StartColorProperty = BindableProperty.Create<RoundEdgeStackLayout, Color>(p => p.StartColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.StartColor = newvalue;
        });

        public Color EndColor { get; set; }
        public static BindableProperty EndColorProperty = BindableProperty.Create<RoundEdgeStackLayout, Color>(p => p.EndColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.EndColor = newvalue;
        });

        public double CornerRadius { get; set; }
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create<RoundEdgeStackLayout, double>(p => p.CornerRadius, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.CornerRadius = newvalue;
        });

        public CornerRadiusReference CornerWRT { get; set; }

        public bool HasBorderColor { get; set; }
        public static BindableProperty HasBorderColorProperty = BindableProperty.Create<RoundEdgeStackLayout, bool>(p => p.HasBorderColor, defaultValue: false, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.HasBorderColor = newvalue;
        });

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

    public enum CornerEdgeStyle
    {
        None,
        Rounded
    }
}

