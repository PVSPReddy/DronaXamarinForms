using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinViews
{
    public partial class ButtonDemo : ContentPage
    {
        public ButtonDemo()
        {
            InitializeComponent();
            button2.Clicked += button2Clicked;

            button3.Clicked += async (object sender, EventArgs e) =>
            {
                await DisplayAlert("Alert", "Button3 has been clicked", "Ok");
            };

            button4.Clicked += (object sender, EventArgs e) =>
            {
                DisplayAlert("Alert", "Button4 has been clicked", "Ok");
            };
        }

        void button1Clicked(object sender, EventArgs e)
        {
            try
            {
                DisplayAlert("Alert", "Button1 has been clicked", "Ok");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        async void button2Clicked(object sender, EventArgs e)
        {
            try
            {
                await DisplayAlert("Alert", "Button2 has been clicked", "Ok");
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
                Navigation.PushModalAsync(new SwitchDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}
