using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinViews
{
    public partial class BoxViewDemo : ContentPage
    {
        public BoxViewDemo()
        {
            InitializeComponent();
        }

        async void Box1Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Box has been tapped", "Ok");
        }

        void backBtnClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync(false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        void startPageBtnClicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new LabelDemo();
                //Navigation.PushModalAsync(new LabelDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }


        void nextBtnClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new ActivityIndicatorDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
