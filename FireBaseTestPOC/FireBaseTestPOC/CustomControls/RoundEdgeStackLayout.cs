using System;

using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class RoundEdgeStackLayout : StackLayout
    {
        public GradientStyle GradientDirection
        {
            get
            {
                return (GradientStyle)GetValue(GradientDirectionProperty);
            }
            set
            {
                SetValue(GradientDirectionProperty, value);
            }
        }
        public static BindableProperty GradientDirectionProperty = BindableProperty.Create<RoundEdgeStackLayout, GradientStyle>(p => p.GradientDirection, defaultValue: GradientStyle.None, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.GradientDirection = newvalue;
        });

        public Color StartColor
        {
            get
            {
                return (Color)GetValue(StartColorProperty);
            }
            set
            {
                SetValue(StartColorProperty, value);
            }
        }
        public static BindableProperty StartColorProperty = BindableProperty.Create<RoundEdgeStackLayout, Color>(p => p.StartColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.StartColor = newvalue;
        });

        public Color EndColor
        {
            get
            {
                return (Color)GetValue(EndColorProperty);
            }
            set
            {
                SetValue(EndColorProperty, value);
            }
        }
        public static BindableProperty EndColorProperty = BindableProperty.Create<RoundEdgeStackLayout, Color>(p => p.EndColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.EndColor = newvalue;
        });

        public double CornerRadius
        {
            get
            {
                return (double)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create<RoundEdgeStackLayout, double>(p => p.CornerRadius, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.CornerRadius = newvalue;
        });

        public CornerRadiusReference CornerWRT
        {
            get
            {
                return (CornerRadiusReference)GetValue(CornerWRTProperty);
            }
            set
            {
                SetValue(CornerWRTProperty, value);
            }
        }
        public static BindableProperty CornerWRTProperty = BindableProperty.Create<RoundEdgeStackLayout, CornerRadiusReference>(p => p.CornerWRT, defaultValue: CornerRadiusReference.WRTHeightRequest, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.CornerWRT = newvalue;
        });

        public bool HasBorderColor
        {
            get
            {
                return (bool)GetValue(HasBorderColorProperty);
            }
            set
            {
                SetValue(HasBorderColorProperty, value);
            }
        }
        public static BindableProperty HasBorderColorProperty = BindableProperty.Create<RoundEdgeStackLayout, bool>(p => p.HasBorderColor, defaultValue: false, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.HasBorderColor = newvalue;
        });

        public double BorderThickness
        {
            get
            {
                return (double)GetValue(BorderThicknessProperty);
            }
            set
            {
                SetValue(BorderThicknessProperty, value);
            }
        }
        public static BindableProperty BorderThicknessProperty = BindableProperty.Create<RoundEdgeStackLayout, double>(p => p.BorderThickness, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.BorderThickness = newvalue;
        });

        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }
        public static BindableProperty BorderColorProperty = BindableProperty.Create<RoundEdgeStackLayout, Color>(p => p.BorderColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.BorderColor = newvalue;
        });

        public RoundEdgeStackLayout() { }
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
/*
public GradientStyle GradientDirection
        {
            get
            {
                return (GradientStyle)GetValue(GradientDirectionProperty);
            }
            set
            {
                SetValue(GradientDirectionProperty, value);
            }
        }//{ get; set; }
        public static BindableProperty GradientDirectionProperty = BindableProperty.Create<RoundEdgeStackLayout, GradientStyle>(p => p.GradientDirection, defaultValue: GradientStyle.None, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.GradientDirection = newvalue;
        });

        public Color StartColor
        {
            get
            {
                return (Color)GetValue(StartColorProperty);
            }
            set
            {
                SetValue(StartColorProperty, value);
            }
        }//{ get; set; }
        public static BindableProperty StartColorProperty = BindableProperty.Create<RoundEdgeStackLayout, Color>(p => p.StartColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.StartColor = newvalue;
        });

        public Color EndColor
        {
            get
            {
                return (Color)GetValue(EndColorProperty);
            }
            set
            {
                SetValue(EndColorProperty, value);
            }
        }//{ get; set; }
        public static BindableProperty EndColorProperty = BindableProperty.Create<RoundEdgeStackLayout, Color>(p => p.EndColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.EndColor = newvalue;
        });

        public double CornerRadius
        {
            get
            {
                return (double)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }//{ get; set; }
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create<RoundEdgeStackLayout, double>(p => p.CornerRadius, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.CornerRadius = newvalue;
        });

        public CornerRadiusReference CornerWRT
        {
            get
            {
                return (CornerRadiusReference)GetValue(CornerWRTProperty);
            }
            set
            {
                SetValue(CornerWRTProperty, value);
            }
        }//{ get; set; }
        public static BindableProperty CornerWRTProperty = BindableProperty.Create<RoundEdgeStackLayout, CornerRadiusReference>(p => p.CornerWRT, defaultValue: CornerRadiusReference.WRTHeightRequest, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.CornerWRT = newvalue;
        });

        public bool HasBorderColor
        {
            get
            {
                return (bool)GetValue(HasBorderColorProperty);
            }
            set
            {
                SetValue(HasBorderColorProperty, value);
            }
        }//{ get; set; }
        public static BindableProperty HasBorderColorProperty = BindableProperty.Create<RoundEdgeStackLayout, bool>(p => p.HasBorderColor, defaultValue: false, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.HasBorderColor = newvalue;
        });

        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }//{ get; set; }
        public static BindableProperty BorderColorProperty = BindableProperty.Create<RoundEdgeStackLayout, Color>(p => p.BorderColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (RoundEdgeStackLayout)bindable;
            ctrl.BorderColor = newvalue;
        });
*/