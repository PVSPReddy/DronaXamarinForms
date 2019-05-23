using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class CustomEntry : Entry
    {
        #region for bindable properties
        #region for Advanced Types
        public string RegexValidatorString
        {
            get
            {
                return (string)GetValue(RegexValidatorStringProperty);
            }
            set
            {
                SetValue(RegexValidatorStringProperty, value);
            }
        }
        public static BindableProperty RegexValidatorStringProperty = BindableProperty.Create<CustomEntry, string>(p => p.RegexValidatorString, defaultValue: "(.*)", propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntry)bindable;
            ctrl.RegexValidatorString = newvalue;
        });
        public bool AllowValidatedTextOnly
        {
            get
            {
                return (bool)GetValue(AllowValidatedTextOnlyProperty);
            }
            set
            {
                SetValue(AllowValidatedTextOnlyProperty, value);
            }
        }
        public static BindableProperty AllowValidatedTextOnlyProperty = BindableProperty.Create<CustomEntry, bool>(p => p.AllowValidatedTextOnly, defaultValue: false, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntry)bindable;
            ctrl.AllowValidatedTextOnly = newvalue;
        });
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(propertyName: "IsValid", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: default(bool));
        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }
        //public bool ShallCheckValidation
        //{
        //    get
        //    {
        //        return (bool)GetValue(ShallCheckValidationProperty);
        //    }
        //    set
        //    {
        //        SetValue(ShallCheckValidationProperty, value);
        //    }
        //}
        //public static BindableProperty ShallCheckValidationProperty = BindableProperty.Create<CustomEntry, bool>(p => p.ShallCheckValidation, defaultValue: false, propertyChanging: (bindable, oldvalue, newvalue) =>
        //{
        //    var ctrl = (CustomEntry)bindable;
        //    ctrl.ShallCheckValidation = newvalue;
        //});
        #endregion
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


        public CustomEntry()
        {
            TextChanged += EntryTextChangedEvents;
        }

        private void EntryTextChangedEvents(object sender, TextChangedEventArgs e)
        {
            if(AllowValidatedTextOnly)
            {
                var owner = (Entry)sender;
                string valueText = owner.Text;
                if (!(string.IsNullOrEmpty(valueText)))
                {
                    bool isValidText = false;
                    if (owner.Keyboard == Keyboard.Numeric)
                    {
                        while (!isValidText)
                        {
                            var regexString = @"^" + RegexValidatorString + "$";
                            if (Regex.IsMatch(valueText, regexString))
                            {
                                isValidText = true;
                            }
                            else
                            {
                                if (valueText.Length > 0)
                                {
                                    valueText = valueText.Remove(valueText.Length - 1);
                                }
                                else
                                {
                                    isValidText = true;
                                }
                            }
                        }

                    }
                }
                else
                {
                }
                owner.Text = valueText;
            }
        }

        public async Task<bool> Validate()
        {
            bool isValid = false;
            try
            {
                var regexString = @"^" + RegexValidatorString + "$";
                if (Regex.IsMatch(Text, regexString))
                {
                    isValid = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
            IsValid = isValid;
            return isValid;
        }

        public async Task<bool> Validate(string _regexValidatorString)
        {
            bool isValid = false;
            try
            {
                var regexString = @"^" + _regexValidatorString + "$";
                if (Regex.IsMatch(Text, regexString))
                {
                    isValid = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
            IsValid = isValid;
            return isValid;
        }

        #endregion

    }

    //public enum EntryKeyBoardType
    //{
    //    Numeric, 
    //}
}