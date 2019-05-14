using System;

using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class CustomPicker : Picker
    {
        public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "EnterText", returnType: typeof(string), declaringType: typeof(CustomPicker), defaultValue: default(string));
        public string EnterText 
        {
            get
            {
                return (string)GetValue(EnterTextProperty);
            }
            set
            {
                SetValue(EnterTextProperty, value);
            }
        }

        public static readonly BindableProperty CustomFontFamilyProperty = BindableProperty.Create(propertyName: "CustomFontFamily", returnType: typeof(string), declaringType: typeof(CustomPicker), defaultValue: default(string));
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

        public static readonly BindableProperty CustomFontSizeProperty = BindableProperty.Create(propertyName: "CustomFontSize", returnType: typeof(float), declaringType: typeof(CustomPicker), defaultValue: default(float));
        public float CustomFontSize
        {
            get
            {
                return (float)GetValue(CustomFontSizeProperty);
            }
            set
            {
                SetValue(CustomFontSizeProperty, value);
            }
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(propertyName: "BorderColor", returnType: typeof(Color), declaringType: typeof(CustomPicker), defaultValue: Color.Transparent);
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

        //for ios as the customcontrol takes any margin if not set in the render itself.
        public static readonly BindableProperty IsRequiredMarginProperty = BindableProperty.Create(propertyName: "IsRequiredMargin", returnType: typeof(bool), declaringType: typeof(CustomPicker), defaultValue: false);
        public bool IsRequiredMargin
        {
            get
            {
                return (bool)GetValue(IsRequiredMarginProperty);
            }
            set
            {
                SetValue(IsRequiredMarginProperty, value);
            }
        }

        public enum BorderType { Rectangle, RectangleWithRoundCorners, SingleLine, None }
        public static readonly BindableProperty BorderTypesProperty = BindableProperty.Create(propertyName: "BorderTypes", returnType: typeof(BorderType), declaringType: typeof(CustomPicker), defaultValue: BorderType.None);
        public BorderType BorderTypes
        {
            get
            {
                return (BorderType)GetValue(BorderTypesProperty);
            }
            set
            {
                SetValue(BorderTypesProperty, value);
            }
        }
    }
}