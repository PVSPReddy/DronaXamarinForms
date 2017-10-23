using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinViews
{
    public partial class LabelDemo : ContentPage
    {
        public LabelDemo()
        {
            InitializeComponent();
        }

        async void lbl1Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Label has been tapped", "Ok");
        }

        void backBtnClicked(object sender, EventArgs e)
        {
            try
            {

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
                Navigation.PushModalAsync(new EntryDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}
