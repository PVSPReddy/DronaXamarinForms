using System;
using System.Runtime.CompilerServices;
using FireBaseTestPOC.Helpers;
using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class CustomEntryGroup : ContentView
    {
        public event EventHandler<EventArgs> OnCustomTextChanged;

        #region for bindable properties
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

        private void OnEntryFieldTextChanged(object sender, TextChangedEventArgs e)
        {
            var owner = (Entry)sender;
            Value = owner.Text;
            if (!(string.IsNullOrEmpty(owner.Text)))
            {
                //caption.IsVisible = true;
                caption.Opacity = 1;
            }
            else
            {
                //caption.IsVisible = false;
                caption.Opacity = 0;
            }
            EventHandler<EventArgs> handler = OnCustomTextChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}