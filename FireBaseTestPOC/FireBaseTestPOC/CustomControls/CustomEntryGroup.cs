using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using FireBaseTestPOC.Helpers;
using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class CustomEntryGroup : ContentView
    {
        public event EventHandler<EventArgs> OnCustomTextChanged;

        #region for bindable properties
        #region for Advanced Types
        public Keyboard CustomKeyboard { get; set; }
        public static BindableProperty CustomKeyboardProperty = BindableProperty.Create<CustomEntryGroup, Keyboard>(p => p.CustomKeyboard, defaultValue: Keyboard.Text, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomKeyboard = newvalue;
        });
        #endregion

        #region for colors
        public Color BorderColor { get; set; }
        public static BindableProperty BorderColorProperty = BindableProperty.Create<CustomEntryGroup, Color>(p => p.BorderColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.BorderColor = newvalue;
        });
        public Color TextColor { get; set; }
        public static BindableProperty TextColorProperty = BindableProperty.Create<CustomEntryGroup, Color>(p => p.TextColor, defaultValue: Color.Black, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.TextColor = newvalue;
        });
        public Color CustomBackGroundColor { get; set; }
        public static BindableProperty CustomBackGroundColorProperty = BindableProperty.Create<CustomEntryGroup, Color>(p => p.CustomBackGroundColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomBackGroundColor = newvalue;
        });
        public Color CustomEntryBackGroundColor { get; set; }
        public static BindableProperty CustomEntryBackGroundColorProperty = BindableProperty.Create<CustomEntryGroup, Color>(p => p.CustomEntryBackGroundColor, defaultValue: Color.White, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomEntryBackGroundColor = newvalue;
        });
        #endregion

        #region for Text Values
        public string CustomPlaceholder { get; set; }
        public static BindableProperty CustomPlaceholderProperty = BindableProperty.Create<CustomEntryGroup, string>(p => p.CustomPlaceholder, defaultValue: String.Empty, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomPlaceholder = newvalue;
        });
        public string CustomFontFamily { get; set; }
        public static BindableProperty CustomFontFamilyProperty = BindableProperty.Create<CustomEntryGroup, string>(p => p.CustomFontFamily, defaultValue: String.Empty, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomFontFamily = newvalue;
        });
        #endregion

        #region for Dimension values
        public double CornerRadius { get; set; }
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create<CustomEntryGroup, double>(p => p.CornerRadius, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CornerRadius = newvalue;
        });
        public double CaptionFontSize { get; set; }
        public static BindableProperty CaptionFontSizeProperty = BindableProperty.Create<CustomEntryGroup, double>(p => p.CaptionFontSize, defaultValue: 10.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CaptionFontSize = newvalue;
        });
        #endregion

        #region for confirmation values
        public bool ShallAddBorder { get; set; }
        public static BindableProperty ShallAddBorderProperty = BindableProperty.Create<CustomEntryGroup, bool>(p => p.ShallAddBorder, defaultValue: false, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.ShallAddBorder = newvalue;
        });
        #endregion

        #region for confirmation values
        public CornerEdgeStyle CornerEdgeType { get; set; }
        public static BindableProperty CornerEdgeTypeProperty = BindableProperty.Create<CustomEntryGroup, CornerEdgeStyle>(p => p.CornerEdgeType, defaultValue: CornerEdgeStyle.None, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CornerEdgeType = newvalue;
        });
        #endregion

        #region to get value from caller
        //public new string _Value;
        //public new string Value
        //{
        //    get
        //    {
        //        return _Value;
        //    }
        //    set
        //    {
        //        _Value = value;
        //    }
        //}
        public string Value { get; set; }
        public static BindableProperty ValueProperty = BindableProperty.Create<CustomEntryGroup, string>(p => p.Value, defaultValue: "", propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.Value = newvalue;
        });
        #endregion

        #endregion

        Label caption;
        CustomEntry entryField;
        RoundEdgeStackLayout stackFieldsHolder, stackMainHolder;

        public CustomEntryGroup()
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
                //VerticalOptions = LayoutOptions.End
                VerticalOptions = LayoutOptions.Center
            };
            entryField.SetBinding(Entry.TextColorProperty, new Binding("TextColor"));
            entryField.SetBinding(Entry.PlaceholderColorProperty, new Binding("TextColor"));
            entryField.SetBinding(Entry.PlaceholderProperty, new Binding("CustomPlaceholder"));
            entryField.SetBinding(Entry.FontFamilyProperty, new Binding("CustomFontFamily"));
            entryField.SetBinding(Entry.KeyboardProperty, new Binding("CustomKeyboard"));
            entryField.TextChanged += OnEntryFieldTextChanged;
            //entryField.PropertyChanged += EntryFieldPropertyChanged;

            //StackLayout stackFieldsHolder = new StackLayout()
            //{
            //    Children = { caption, entryField },
            //    BackgroundColor = Color.White,
            //    //Padding = new Thickness(2, 2, 2, 2),
            //    Margin = new Thickness(2),
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //}; 
            stackFieldsHolder = new RoundEdgeStackLayout()
            {
                Children = { caption, entryField },
                //BackgroundColor = Color.White,
                Padding = new Thickness(2),
                Margin = new Thickness(2),
                GradientDirection = GradientStyle.None,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //stackFieldsHolder.SetBinding(StackLayout.BackgroundColorProperty, new Binding("CustomEntryBackGroundColor"));

            //StackLayout stackBorderLayout = new StackLayout()
            //{
            //    Children = { stackFieldsHolder },
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
            //stackBorderLayout.SetBinding(StackLayout.BackgroundColorProperty, new Binding("BorderColor"));

            stackMainHolder = new RoundEdgeStackLayout()
            {
                Children = { stackFieldsHolder },
                Margin = new Thickness(2),
                GradientDirection = GradientStyle.None,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            ////stackMainHolder.SetBinding(RoundEdgeStackLayout.BackgroundColorProperty, new Binding("BorderColor"));
            //stackMainHolder.SetBinding(RoundEdgeStackLayout.StartColorProperty, new Binding("BorderColor"));
            //stackMainHolder.SetBinding(RoundEdgeStackLayout.EndColorProperty, new Binding("BorderColor"));
            //stackMainHolder.SetBinding(RoundEdgeStackLayout.HasBorderColorProperty, new Binding("ShallAddBorder"));
            ////stackMainHolder.SetBinding(RoundEdgeStackLayout., new Binding("BorderColor"));
            ////stackMainHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("BorderColor"));
            //stackMainHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("CornerRadius"));

            Content = stackMainHolder;
        }

        //void EntryFieldPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    try
        //    {
        //        var owner = (Entry)sender;
        //        if (e.PropertyName == "Text")
        //        {
        //            var textValue = owner.Text;
        //            if(!(string.IsNullOrEmpty(textValue)))
        //            {
        //                if (CornerEdgeType == CornerEdgeStyle.None)
        //                {
        //                }
        //                else if (CornerEdgeType == CornerEdgeStyle.Rounded)
        //                {
        //                    stackMainHolder.StartColor = BorderColor;
        //                    stackMainHolder.EndColor = BorderColor;
        //                }
        //                else
        //                {
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var msg = ex.Message + "\n" + ex.StackTrace;
        //        System.Diagnostics.Debug.WriteLine(msg);
        //    }
        //}


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if(propertyName == "CornerEdgeType")
            {
                if(CornerEdgeType == CornerEdgeStyle.None)
                {

                }
                else if(CornerEdgeType == CornerEdgeStyle.Rounded)
                {
                    stackFieldsHolder.SetBinding(RoundEdgeStackLayout.StartColorProperty, new Binding("CustomEntryBackGroundColor"));
                    stackFieldsHolder.SetBinding(RoundEdgeStackLayout.EndColorProperty, new Binding("CustomEntryBackGroundColor"));
                    stackFieldsHolder.SetBinding(RoundEdgeStackLayout.HasBorderColorProperty, new Binding("ShallAddBorder"));
                    stackFieldsHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("CornerRadius"));


                    ////stackFieldsHolder.SetBinding(RoundEdgeStackLayout.BackgroundColorProperty, new Binding("BorderColor"));
                    //stackFieldsHolder.SetBinding(RoundEdgeStackLayout.StartColorProperty, new Binding("BorderColor"));
                    //stackFieldsHolder.SetBinding(RoundEdgeStackLayout.EndColorProperty, new Binding("BorderColor"));
                    //stackFieldsHolder.SetBinding(RoundEdgeStackLayout.HasBorderColorProperty, new Binding("ShallAddBorder"));
                    ////stackFieldsHolder.SetBinding(RoundEdgeStackLayout., new Binding("BorderColor"));
                    ////stackFieldsHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("BorderColor"));
                    //stackFieldsHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("CornerRadius"));


                    //stackMainHolder.SetBinding(RoundEdgeStackLayout.BackgroundColorProperty, new Binding("BorderColor"));
                    stackMainHolder.SetBinding(RoundEdgeStackLayout.StartColorProperty, new Binding("BorderColor"));
                    stackMainHolder.SetBinding(RoundEdgeStackLayout.EndColorProperty, new Binding("BorderColor"));
                    stackMainHolder.SetBinding(RoundEdgeStackLayout.HasBorderColorProperty, new Binding("ShallAddBorder"));
                    //stackMainHolder.SetBinding(RoundEdgeStackLayout., new Binding("BorderColor"));
                    //stackMainHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("BorderColor"));
                    stackMainHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("CornerRadius"));
                }
            }
        }

        public void OnCustomPropertyChanged(string propertyName = null)
        {
            if (propertyName == "CornerEdgeType")
            {
                if (CornerEdgeType == CornerEdgeStyle.None)
                {

                }
                else if (CornerEdgeType == CornerEdgeStyle.Rounded)
                {
                    stackFieldsHolder.SetBinding(RoundEdgeStackLayout.StartColorProperty, new Binding("CustomEntryBackGroundColor"));
                    stackFieldsHolder.SetBinding(RoundEdgeStackLayout.EndColorProperty, new Binding("CustomEntryBackGroundColor"));
                    stackFieldsHolder.SetBinding(RoundEdgeStackLayout.HasBorderColorProperty, new Binding("ShallAddBorder"));
                    stackFieldsHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("CornerRadius"));


                    ////stackFieldsHolder.SetBinding(RoundEdgeStackLayout.BackgroundColorProperty, new Binding("BorderColor"));
                    //stackFieldsHolder.SetBinding(RoundEdgeStackLayout.StartColorProperty, new Binding("BorderColor"));
                    //stackFieldsHolder.SetBinding(RoundEdgeStackLayout.EndColorProperty, new Binding("BorderColor"));
                    //stackFieldsHolder.SetBinding(RoundEdgeStackLayout.HasBorderColorProperty, new Binding("ShallAddBorder"));
                    ////stackFieldsHolder.SetBinding(RoundEdgeStackLayout., new Binding("BorderColor"));
                    ////stackFieldsHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("BorderColor"));
                    //stackFieldsHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("CornerRadius"));


                    //stackMainHolder.SetBinding(RoundEdgeStackLayout.BackgroundColorProperty, new Binding("BorderColor"));
                    stackMainHolder.SetBinding(RoundEdgeStackLayout.StartColorProperty, new Binding("BorderColor"));
                    stackMainHolder.SetBinding(RoundEdgeStackLayout.EndColorProperty, new Binding("BorderColor"));
                    stackMainHolder.SetBinding(RoundEdgeStackLayout.HasBorderColorProperty, new Binding("ShallAddBorder"));
                    //stackMainHolder.SetBinding(RoundEdgeStackLayout., new Binding("BorderColor"));
                    //stackMainHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("BorderColor"));
                    stackMainHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("CornerRadius"));
                }
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
                if(owner.Keyboard == Keyboard.Numeric)
                {
                    while(!isValidText)
                    {
                        if (Regex.IsMatch(valueText, @"^[0-9]*$"))
                        {
                            isValidText = true;
                        }
                        else
                        {
                            valueText = valueText.Remove(valueText.Length - 1);
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
            Value = owner.Text;
            EventHandler<EventArgs> handler = OnCustomTextChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
/*
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
        }// { get; set; }
        public static BindableProperty CustomKeyboardProperty = BindableProperty.Create<CustomEntryGroup, Keyboard>(p => p.CustomKeyboard, defaultValue: Keyboard.Text, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomKeyboard = newvalue;
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
        }//{ get; set; }
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
        }//{ get; set; }
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
        }//{ get; set; }
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
        }//{ get; set; }
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
        }//{ get; set; }
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
        }//{ get; set; }
        public static BindableProperty CustomFontFamilyProperty = BindableProperty.Create<CustomEntryGroup, string>(p => p.CustomFontFamily, defaultValue: String.Empty, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CustomFontFamily = newvalue;
        });
        #endregion

        #region for Dimension values
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
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create<CustomEntryGroup, double>(p => p.CornerRadius, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CornerRadius = newvalue;
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
        }//{ get; set; }
        public static BindableProperty CaptionFontSizeProperty = BindableProperty.Create<CustomEntryGroup, double>(p => p.CaptionFontSize, defaultValue: 10.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CaptionFontSize = newvalue;
        });
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
        }//{ get; set; }
        public static BindableProperty ShallAddBorderProperty = BindableProperty.Create<CustomEntryGroup, bool>(p => p.ShallAddBorder, defaultValue: false, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.ShallAddBorder = newvalue;
        });
        #endregion

        #region for confirmation values
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
        }//{ get; set; }
        public static BindableProperty CornerEdgeTypeProperty = BindableProperty.Create<CustomEntryGroup, CornerEdgeStyle>(p => p.CornerEdgeType, defaultValue: CornerEdgeStyle.None, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.CornerEdgeType = newvalue;
        });
        #endregion

        #region to get value from caller
        //public new string _Value;
        //public new string Value
        //{
        //    get
        //    {
        //        return _Value;
        //    }
        //    set
        //    {
        //        _Value = value;
        //    }
        //}
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
        }//{ get; set; }
        public static BindableProperty ValueProperty = BindableProperty.Create<CustomEntryGroup, string>(p => p.Value, defaultValue: "", propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntryGroup)bindable;
            ctrl.Value = newvalue;
        });
        #endregion

        #endregion
*/