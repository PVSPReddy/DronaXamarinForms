using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinViews
{
    public partial class SwitchDemo : ContentPage
    {
        public SwitchDemo()
        {
            InitializeComponent();

            textLbl2.BindingContext = switch2;
            textLbl2.SetBinding(Label.IsVisibleProperty, "IsToggled");

            switch3.Toggled += Switch3Toggled;

        }

        void Switch3Toggled(object sender, ToggledEventArgs e)
        {
            try
            {
                var swtch = sender as Switch;
                if (!swtch.IsToggled)
                {
                    textLbl3.TextColor = Color.Maroon;
                }
                else
                {
                    textLbl3.TextColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        void button4Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "This button is now enabled and clicked too", "Ok");
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
                Navigation.PushModalAsync(new Progressbar_Stepper_SliderDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
