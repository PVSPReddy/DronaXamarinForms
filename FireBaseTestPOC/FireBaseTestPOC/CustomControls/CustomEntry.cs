using System;
using FireBaseTestPOC.Helpers;
using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class CustomEntry : ContentView
    {
        public event EventHandler<EventArgs> OnCustomTextChanged;

        #region for bindable properties
        public Color BorderColor { get; set; }
        public static BindableProperty BorderColorProperty = BindableProperty.Create<CustomEntry, Color>(p => p.BorderColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntry)bindable;
            ctrl.BorderColor = newvalue;
        });
        public Color TextColor { get; set; }
        public static BindableProperty TextColorProperty = BindableProperty.Create<CustomEntry, Color>(p => p.TextColor, defaultValue: Color.Black, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntry)bindable;
            ctrl.TextColor = newvalue;
        });
        public Color CustomBackGroundColor { get; set; }
        public static BindableProperty CustomBackGroundColorProperty = BindableProperty.Create<CustomEntry, Color>(p => p.CustomBackGroundColor, defaultValue: Color.Transparent, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntry)bindable;
            ctrl.CustomBackGroundColor = newvalue;
        });
        public Color CustomEntryBackGroundColor { get; set; }
        public static BindableProperty CustomEntryBackGroundColorProperty = BindableProperty.Create<CustomEntry, Color>(p => p.CustomEntryBackGroundColor, defaultValue: Color.White, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntry)bindable;
            ctrl.CustomEntryBackGroundColor = newvalue;
        });

        public string CustomPlaceholder { get; set; }
        public static BindableProperty CustomPlaceholderProperty = BindableProperty.Create<CustomEntry, string>(p => p.CustomPlaceholder, defaultValue: String.Empty, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntry)bindable;
            ctrl.CustomPlaceholder = newvalue;
        });

        public double CornerRadius { get; set; }
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create<CustomEntry, double>(p => p.CornerRadius, defaultValue: 0.00, propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var ctrl = (CustomEntry)bindable;
            ctrl.CornerRadius = newvalue;
        });
        #endregion

        Label caption;
        Entry entryField;

        public CustomEntry()
        {
            BindingContext = this;

            caption = new Label()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };
            caption.SetBinding(Label.TextColorProperty, new Binding("TextColor"));
            caption.SetBinding(Label.TextProperty, new Binding("CustomPlaceholder"));

            entryField = new Entry()
            {
                PlaceholderColor = CustomColors.PlaceholderColor,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End
            };
            entryField.SetBinding(Entry.TextColorProperty, new Binding("TextColor"));
            entryField.SetBinding(Entry.PlaceholderColorProperty, new Binding("TextColor"));
            entryField.SetBinding(Entry.PlaceholderProperty, new Binding("CustomPlaceholder"));
            entryField.TextChanged += OnEntryFieldTextChanged;

            StackLayout stackFieldsHolder = new StackLayout()
            {
                Children = { caption, entryField },
                BackgroundColor = Color.White,
                Padding = new Thickness(2,2,2,2),
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
            if(!(string.IsNullOrEmpty(owner.Text)))
            {
                caption.IsVisible = true;
            }
            else
            {
                caption.IsVisible = false;
            }
            EventHandler<EventArgs> handler = OnCustomTextChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}