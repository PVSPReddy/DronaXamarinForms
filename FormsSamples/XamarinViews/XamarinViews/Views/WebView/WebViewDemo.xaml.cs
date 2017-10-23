using System;
using System.Collections.Generic;

using Xamarin.Forms;

//add NSAppTransportSecurity
//add internet permissions
namespace XamarinViews
{
    public partial class WebViewDemo : ContentPage
    {
        public WebViewDemo()
        {
            InitializeComponent();
            webView.Source = new Uri("http://www.google.com");
            webView.Navigated += async (object sender, WebNavigatedEventArgs e) =>
            {
                try
                {
                    await DisplayAlert("WebView", "Your data is loaded", "Ok");
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
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
                Navigation.PushModalAsync(new ImageDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
