using System;

using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class CustomEntry : Entry
    {
        public CustomEntry(){}

        public static readonly BindableProperty CustomFontFamilyProperty = BindableProperty.Create(propertyName: "CustomFontFamily", returnType: typeof(string), declaringType: typeof(CustomEntry), defaultValue: default(string));
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

        public static readonly BindableProperty CustomFontSizeProperty = BindableProperty.Create(propertyName: "CustomFontSize", returnType: typeof(float), declaringType: typeof(CustomEntry), defaultValue: default(float));
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

        public static readonly BindableProperty IsCustomPasswordProperty = BindableProperty.Create(propertyName: "IsCustomPassword", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
        public bool IsCustomPassword
        {
            get
            {
                return (bool)GetValue(IsCustomPasswordProperty);
            }
            set
            {
                SetValue(IsCustomPasswordProperty, value);
            }
        }

        public static readonly BindableProperty IsPhoneProperty = BindableProperty.Create(propertyName: "IsPhoneNumber", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
        public bool IsPhoneNumber
        {
            get
            {
                return (bool)GetValue(IsPhoneProperty);
            }
            set
            {
                SetValue(IsPhoneProperty, value);
            }
        }

        public static readonly BindableProperty IsNumericProperty = BindableProperty.Create(propertyName: "IsNumeric", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
        public bool IsNumeric
        {
            get
            {
                return (bool)GetValue(IsNumericProperty);
            }
            set
            {
                SetValue(IsNumericProperty, value);
            }
        }

        public static readonly BindableProperty IsEmailProperty = BindableProperty.Create(propertyName: "IsEmail", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
        public bool IsEmail
        {
            get
            {
                return (bool)GetValue(IsEmailProperty);
            }
            set
            {
                SetValue(IsEmailProperty, value);
            }
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(propertyName: "BorderColor", returnType: typeof(Color), declaringType: typeof(CustomEntry), defaultValue: Color.Transparent);
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
        public static readonly BindableProperty IsRequiredMarginProperty = BindableProperty.Create(propertyName: "IsRequiredMargin", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
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
        public static readonly BindableProperty BorderTypesProperty = BindableProperty.Create(propertyName: "BorderTypes", returnType: typeof(BorderType), declaringType: typeof(CustomEntry), defaultValue: BorderType.None);
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

    //public enum EntryKeyBoardType
    //{
    //    Numeric, 
    //}
}