using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinViews
{
    public partial class Date_TimePickerDemo : ContentPage
    {
        public Date_TimePickerDemo()
        {
            InitializeComponent();
        }

        void DatePicked(object sender, DateChangedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            var date = datePicker.Date.Day.ToString() + "-" + datePicker.Date.Month.ToString() + "-" + datePicker.Date.Year.ToString();
            label2.Text = "Here is the formated/refined date from this DatePicker: " + date;
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
                Navigation.PushModalAsync(new ButtonDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}
