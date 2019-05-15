using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FireBaseTestPOC.Helpers;
using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class CustomEntryGroup : ContentView
    {
        #region for bindable properties
        #region for Advanced Types
        public Keyboard CustomKeyboard
        {
            get
            {
                return (Keyboard)GetValue(CustomKeyboardProperty);
            }
            set
            {
                SetValue(CustomKeyboardProperty, value);
            }
        }
        public static BindableProperty CustomKeyboardProperty = BindableProperty.Create<CustomEntryGroup, Keyboard>(p => p.CustomKeyboard, defaultValue: Keyboard.Text, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomKeyboard = newvalue;
        });

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
        public static BindableProperty RegexValidatorStringProperty = BindableProperty.Create<CustomEntryGroup, string>(p => p.RegexValidatorString, defaultValue: "(.*)", propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.RegexValidatorString = newvalue;
        });
        #endregion

        #region for colors
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
        public static BindableProperty BorderColorProperty = BindableProperty.Create<CustomEntryGroup, Color>(p => p.BorderColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.BorderColor = newvalue;
        });
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
        public static BindableProperty TextColorProperty = BindableProperty.Create<CustomEntryGroup, Color>(p => p.TextColor, defaultValue: Color.Black, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.TextColor = newvalue;
        });
        public Color CustomBackGroundColor
        {
            get
            {
                return (Color)GetValue(CustomBackGroundColorProperty);
            }
            set
            {
                SetValue(CustomBackGroundColorProperty, value);
            }
        }
        public static BindableProperty CustomBackGroundColorProperty = BindableProperty.Create<CustomEntryGroup, Color>(p => p.CustomBackGroundColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomBackGroundColor = newvalue;
        });
        public Color CustomEntryBackGroundColor
        {
            get
            {
                return (Color)GetValue(CustomEntryBackGroundColorProperty);
            }
            set
            {
                SetValue(CustomEntryBackGroundColorProperty, value);
            }
        }
        public static BindableProperty CustomEntryBackGroundColorProperty = BindableProperty.Create<CustomEntryGroup, Color>(p => p.CustomEntryBackGroundColor, defaultValue: Color.White, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomEntryBackGroundColor = newvalue;
        });
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
        public static BindableProperty CustomPlaceholderProperty = BindableProperty.Create<CustomEntryGroup, string>(p => p.CustomPlaceholder, defaultValue: String.Empty, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
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
        public static BindableProperty CustomFontFamilyProperty = BindableProperty.Create<CustomEntryGroup, string>(p => p.CustomFontFamily, defaultValue: String.Empty, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomFontFamily = newvalue;
        });
        #endregion

        #region for Dimension values

        public int AllowableTextLength
        {
            get
            {
                return (int)GetValue(AllowableTextLengthProperty);
            }
            set
            {
                SetValue(AllowableTextLengthProperty, value);
            }
        }
        public static BindableProperty AllowableTextLengthProperty = BindableProperty.Create<CustomEntryGroup, int>(p => p.AllowableTextLength, defaultValue: 10000, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.AllowableTextLength = newvalue;
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
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create<CustomEntryGroup, double>(p => p.CornerRadius, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CornerRadius = newvalue;
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
        public static BindableProperty BorderThicknessProperty = BindableProperty.Create<CustomEntryGroup, double>(p => p.BorderThickness, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.BorderThickness = newvalue;
        });
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
        public static BindableProperty CaptionFontSizeProperty = BindableProperty.Create<CustomEntryGroup, double>(p => p.CaptionFontSize, defaultValue: 10.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CaptionFontSize = newvalue;
        });
        public Thickness EntryTextPadding
        {
            get
            {
                return (double)GetValue(EntryTextPaddingProperty);
            }
            set
            {
                SetValue(EntryTextPaddingProperty, value);
            }
        }
        //public static BindableProperty EntryTextPaddingProperty = BindableProperty.Create<CustomEntryGroup, Thickness>(p => p.EntryTextPadding, defaultValue: 0, propertyChanging: (bindable, oldvalue, newvalue) =>
        //{
        //    var ctrl = (CustomEntryGroup)bindable;
        //    ctrl.EntryTextPadding = newvalue;
        //});
        public static readonly BindableProperty EntryTextPaddingProperty = BindableProperty.Create("EntryTextPadding", typeof(Thickness), typeof(CustomEntryGroup), new Thickness(-1.0));
        //public Thickness EntryTextPadding { get; set; }
        #endregion

        #region for confirmation values
        public bool ShallAddBorder
        {
            get
            {
                return (bool)GetValue(ShallAddBorderProperty);
            }
            set
            {
                SetValue(ShallAddBorderProperty, value);
            }
        }
        public static BindableProperty ShallAddBorderProperty = BindableProperty.Create<CustomEntryGroup, bool>(p => p.ShallAddBorder, defaultValue: false, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.ShallAddBorder = newvalue;
        });

        public CornerEdgeStyle CornerEdgeType
        {
            get
            {
                return (CornerEdgeStyle)GetValue(CornerEdgeTypeProperty);
            }
            set
            {
                SetValue(CornerEdgeTypeProperty, value);
            }
        }
        public static BindableProperty CornerEdgeTypeProperty = BindableProperty.Create<CustomEntryGroup, CornerEdgeStyle>(p => p.CornerEdgeType, defaultValue: CornerEdgeStyle.None, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CornerEdgeType = newvalue;
        });
        #endregion

        #region to get value from caller
        public string Value
        {
            get
            {
                return (string)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }
        public static BindableProperty ValueProperty = BindableProperty.Create<CustomEntryGroup, string>(p => p.Value, defaultValue: "", propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.Value = newvalue;
        });
        public object PickerValue
        {
            get
            {
                return (object)GetValue(PickerValueProperty);
            }
            set
            {
                SetValue(PickerValueProperty, value);
            }
        }
        public static BindableProperty PickerValueProperty = BindableProperty.Create<CustomEntryGroup, object>(p => p.PickerValue, defaultValue: null, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.PickerValue = newvalue;
        });
        #endregion

        #region for picker items source
        public IList ItemsSource
        {
            get
            {
                return (IList)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }
        public static BindableProperty ItemsSourceProperty = BindableProperty.Create<CustomEntryGroup, IList>(p => p.ItemsSource, defaultValue: null, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.ItemsSource = newvalue;
        });
        #endregion
        #endregion

        Label caption;
        CustomEntry entryField;
        CustomPicker pickerField;
        StackLayout stackFieldsHolder;
        RoundEdgeStackLayout stackMainHolder;

        MainFieldType mainFieldType;

        public event EventHandler<EventArgs> OnCustomTextChanged;
        public event EventHandler<EventArgs> OnSelectedIndexChanged;

        public CustomEntryGroup(MainFieldType _mainFieldType)
        {
            mainFieldType = _mainFieldType;
            SetLayout(_mainFieldType);
        }

        public void SetLayout(MainFieldType _mainFieldType)
        {
            BindingContext = this;

            MinimumHeightRequest = 20;

            caption = new Label()
            {
                //IsVisible = false,
                Opacity = 0,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };
            caption.SetBinding(Label.TextColorProperty, new Binding("TextColor"));
            caption.SetBinding(Label.TextProperty, new Binding("CustomPlaceholder"));
            caption.SetBinding(Label.FontSizeProperty, new Binding("CaptionFontSize"));
            caption.SetBinding(Label.FontFamilyProperty, new Binding("CustomFontFamily"));

            entryField = new CustomEntry()
            {
                PlaceholderColor = CustomColors.PlaceholderColor,
                BorderTypes = CustomEntry.BorderType.None,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            entryField.SetBinding(Entry.TextProperty, "Value", BindingMode.TwoWay); //BindingMode.TwoWay, null, null);
            entryField.SetBinding(Entry.TextColorProperty, new Binding("TextColor"));
            entryField.SetBinding(Entry.PlaceholderColorProperty, new Binding("TextColor"));
            entryField.SetBinding(Entry.PlaceholderProperty, new Binding("CustomPlaceholder"));
            entryField.SetBinding(Entry.FontFamilyProperty, new Binding("CustomFontFamily"));
            entryField.SetBinding(Entry.KeyboardProperty, new Binding("CustomKeyboard"));
            entryField.TextChanged += OnEntryFieldTextChanged;

            pickerField = new CustomPicker()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            //pickerField.ItemsSource = 
            pickerField.SetBinding(Picker.TextColorProperty, new Binding("TextColor"));
            pickerField.SetBinding(Picker.TitleProperty, new Binding("CustomPlaceholder"));
            pickerField.SetBinding(Picker.FontSizeProperty, new Binding("CaptionFontSize"));
            pickerField.SetBinding(Picker.FontFamilyProperty, new Binding("CustomFontFamily"));
            pickerField.SetBinding(Picker.ItemsSourceProperty, new Binding("ItemsSource"));
            pickerField.SelectedIndexChanged += OnItemSelected;

            stackFieldsHolder = new StackLayout()
            {
                Children = { caption },
                Padding = new Thickness(2),
                Margin = new Thickness(2),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            switch (_mainFieldType)
            {
                case MainFieldType.EntryField :
                    stackFieldsHolder.Children.Add(entryField);
                    break;
                case MainFieldType.PickerField:
                    stackFieldsHolder.Children.Add(pickerField);
                    break;
                default :
                    break;
            }

            stackMainHolder = new RoundEdgeStackLayout()
            {
                Children = { stackFieldsHolder },
                Margin = new Thickness(2),
                GradientDirection = GradientStyle.None,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            stackMainHolder.SetBinding(RoundEdgeStackLayout.StartColorProperty, new Binding("CustomEntryBackGroundColor"));
            stackMainHolder.SetBinding(RoundEdgeStackLayout.EndColorProperty, new Binding("CustomEntryBackGroundColor"));
            stackMainHolder.SetBinding(RoundEdgeStackLayout.BorderColorProperty, new Binding("BorderColor"));
            stackMainHolder.SetBinding(RoundEdgeStackLayout.HasBorderColorProperty, new Binding("ShallAddBorder"));
            stackMainHolder.SetBinding(RoundEdgeStackLayout.BorderThicknessProperty, new Binding("BorderThickness"));
            //stackMainHolder.SetBinding(RoundEdgeStackLayout.PaddingProperty, new Binding("EntryTextPadding"));
            stackMainHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("CornerRadius"));

            Content = stackMainHolder;
        }

        private void OnItemSelected(object sender, EventArgs e)
        {
            var owner = (CustomPicker)sender;
            if (owner.SelectedIndex != -1)
            {
                if(string.IsNullOrEmpty(owner.SelectedItem.ToString()))
                {
                    caption.Opacity = 0;
                }
                else
                {
                    caption.Opacity = 1;
                }
                PickerValue = owner.SelectedItem;
            }
            EventHandler<EventArgs> handler = OnSelectedIndexChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if(propertyName == "EntryTextPadding")
            {
                //stackFieldsHolder.Padding = EntryTextPadding;//new Thickness(10, 0, 10, 0);
                stackMainHolder.Padding = new Thickness(10, 0, 10, 0);//EntryTextPadding;//new Thickness(10, 0, 10, 0);
            }
        }

        private void OnEntryFieldTextChanged(object sender, TextChangedEventArgs e)
        {
            var owner = (Entry)sender;
            string valueText = owner.Text;
            if (!(string.IsNullOrEmpty(valueText)))
            {
                //caption.IsVisible = true;
                caption.Opacity = 1;
                bool isValidText = false;
                while (!isValidText)
                {
                    var regexString = @"^" + RegexValidatorString + "$";
                    //var regexString = @"^([0-9]{0," + AllowableTextLength + "})$"; //@"^([0-9]{0,4})$";//@"^("+"[0-9]"+ "{0, "+AllowableTextLength+"})$";
                    //if (Regex.IsMatch(valueText, @"^[0-9]*$"))//[0-9]{0,4}
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
            else
            {
                //caption.IsVisible = false;
                caption.Opacity = 0;
            }
            owner.Text = valueText;
            //Value = owner.Text;
            EventHandler<EventArgs> handler = OnCustomTextChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public async Task<bool> Validate( string textValue = "", string _regexValidatorString = "(.*)")
        {
            bool isValid = false;
            try
            {
                var regexString = @"^" + _regexValidatorString + "$";
                if (Regex.IsMatch(textValue, regexString))
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
            return isValid;
        }
    }
    public enum MainFieldType
    {
        EntryField, PickerField
    }
}