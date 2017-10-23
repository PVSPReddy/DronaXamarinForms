using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinViews
{
    public partial class ActivityIndicatorDemo : ContentPage
    {
        public ActivityIndicatorDemo()
        {
            InitializeComponent();
        }

        async void AI1Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Box has been tapped", "Ok");
        }

        void AccessActivityIndicator(object sender, EventArgs e)
        {
            try
            {
                AI1.IsRunning = AI1.IsRunning ? false : true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
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
                Navigation.PushModalAsync(new MapViewDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
