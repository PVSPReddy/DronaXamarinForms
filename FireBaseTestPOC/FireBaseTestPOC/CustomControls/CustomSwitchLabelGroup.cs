using System;

using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class CustomSwitchLabelGroup : ContentView
    {
        #region for bindable properties

        #region to get value from caller
        public bool IsToggled
        {
            get
            {
                return (bool)GetValue(IsToggledProperty);
            }
            set
            {
                SetValue(IsToggledProperty, value);
            }
        }
        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(propertyName: "IsToggled", returnType: typeof(bool), declaringType: typeof(CustomSwitchLabelGroup), defaultValue: default(bool));
        #endregion

        #region for Text Values
        public string CustomPlaceholder
        {
            get
            {
                return (string)GetValue(CustomPlaceholderProperty);
            }
            set
            {
                SetValue(CustomPlaceholderProperty, value);
            }
        }
        public static BindableProperty CustomPlaceholderProperty = BindableProperty.Create<CustomSwitchLabelGroup, string>(p => p.CustomPlaceholder, defaultValue: String.Empty, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomSwitchLabelGroup)bindable;
            ctrl.CustomPlaceholder = newvalue;
        });
        public string CustomFontFamily
        {
            get
            {
                return (string)GetValue(CustomFontFamilyProperty);
            }
            set
            {
                SetValue(CustomFontFamilyProperty, value);
            }
        }
        public static BindableProperty CustomFontFamilyProperty = BindableProperty.Create<CustomSwitchLabelGroup, string>(p => p.CustomFontFamily, defaultValue: String.Empty, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomSwitchLabelGroup)bindable;
            ctrl.CustomFontFamily = newvalue;
        });
        #endregion

        #region for colors
        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }
        public static BindableProperty TextColorProperty = BindableProperty.Create<CustomSwitchLabelGroup, Color>(p => p.TextColor, defaultValue: Color.Black, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomSwitchLabelGroup)bindable;
            ctrl.TextColor = newvalue;
        });
        #endregion

        #region for Dimension values
        public double CaptionFontSize
        {
            get
            {
                return (double)GetValue(CaptionFontSizeProperty);
            }
            set
            {
                SetValue(CaptionFontSizeProperty, value);
            }
        }
        public static BindableProperty CaptionFontSizeProperty = BindableProperty.Create<CustomSwitchLabelGroup, double>(p => p.CaptionFontSize, defaultValue: 10.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomSwitchLabelGroup)bindable;
            ctrl.CaptionFontSize = newvalue;
        });
        #endregion

        #endregion

        public event EventHandler<ToggledEventArgs> Toggled;

        StackLayout stackFieldsHolder;
        Label labelCaption;
        Switch switchControl;
        public CustomSwitchLabelGroup()
        {

            BindingContext = this;

            MinimumHeightRequest = 20;

            labelCaption = new Label()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            labelCaption.SetBinding(Label.TextColorProperty, new Binding("TextColor"));
            labelCaption.SetBinding(Label.TextProperty, new Binding("CustomPlaceholder"));
            labelCaption.SetBinding(Label.FontSizeProperty, new Binding("CaptionFontSize"));
            labelCaption.SetBinding(Label.FontFamilyProperty, new Binding("CustomFontFamily"));

            switchControl = new Switch()
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };
            switchControl.SetBinding(Switch.IsToggledProperty, "IsToggled", BindingMode.TwoWay);
            switchControl.Toggled += OnSwitchToggledEvent;

            stackFieldsHolder = new StackLayout()
            {
                Children = { labelCaption, switchControl },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(2),
                Margin = new Thickness(2),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = stackFieldsHolder;
        }

        private void OnSwitchToggledEvent(object sender, ToggledEventArgs e)
        {
            EventHandler<ToggledEventArgs> handler = Toggled;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}