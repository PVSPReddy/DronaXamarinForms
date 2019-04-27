using System;
using FireBaseTestPOC.Helpers;
using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class CustomEntryGroup : ContentView
    {
        public event EventHandler<EventArgs> OnCustomTextChanged;

        #region for bindable properties
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

        Label caption;
        CustomEntry entryField;

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

            StackLayout stackFieldsHolder = new StackLayout()
            {
                Children = { caption, entryField },
                BackgroundColor = Color.White,
                Padding = new Thickness(2, 2, 2, 2),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            stackFieldsHolder.SetBinding(StackLayout.BackgroundColorProperty, new Binding("CustomEntryBackGroundColor"));

            //StackLayout stackBorderLayout = new StackLayout()
            //{
            //    Children = { stackFieldsHolder },
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
            //stackBorderLayout.SetBinding(StackLayout.BackgroundColorProperty, new Binding("BorderColor"));

            RoundEdgeStackLayout stackMainHolder = new RoundEdgeStackLayout()
            {
                Children = { stackFieldsHolder },
                BindingContext = this,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            stackMainHolder.SetBinding(StackLayout.BackgroundColorProperty, new Binding("BorderColor"));
            stackMainHolder.SetBinding(RoundEdgeStackLayout.CornerRadiusProperty, new Binding("CornerRadius"));

            Content = stackMainHolder;
        }

        private void OnEntryFieldTextChanged(object sender, TextChangedEventArgs e)
        {
            var owner = (Entry)sender;
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