using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinLayouts
{
    public partial class StackLayoutDemo : ContentPage
    {
        public StackLayoutDemo()
        {
            InitializeComponent();
            #region for providing screen heights/widths dynamically for different screen/devices
            var screenHeight = (App.screenHeight * 1) / 100;
            var screenWidth = (App.screenWidth * 1) / 100;

            headerStack.HeightRequest = screenHeight * 10;
            bodyStack.HeightRequest = screenHeight * 80;
            footerStack.HeightRequest = screenHeight * 10;
            #endregion
            bool isMobNoFine = false;
            mobNoEntry.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
                    long i = -1;
                    var entry = sender as Entry;
                    isMobNoFine = Int64.TryParse(entry.Text, out i);
                    if (!(Int64.TryParse(entry.Text, out i)))
                    {
                        mobNoEntry.TextColor = Color.Red;
                    }
                    else
                    {
                        mobNoEntry.TextColor = Color.Default;
                        if (entry.Text.Length <= 10)
                        {
                            isMobNoFine = true;
                            mobNoEntry.TextColor = Color.Default;
                        }
                        else
                        {
                            mobNoEntry.TextColor = Color.Red;
                            isMobNoFine = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };

            submit.Clicked += (object sender, EventArgs e) =>
            {
                try
                {
                    if (string.IsNullOrEmpty(mobNoEntry.Text))
                    {
                        DisplayAlert("Alert", "Mobile Number field should not be empty", "Ok");
                    }
                    else if (mobNoEntry.Text.Length != 10 || isMobNoFine != true)
                    {
                        DisplayAlert("Alert", "Enter a Valid Mobile Number", "Ok");
                    }
                    else if (string.IsNullOrEmpty(passEntry.Text))
                    {
                        DisplayAlert("Alert", "Password sholud not be empty", "Ok");
                    }
                    else
                    {
                        DisplayAlert("Alert", "Validation is successful", "Ok");
                    }
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
                Navigation.PushModalAsync(new StartPage(), false);
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
                Navigation.PushModalAsync(new GridDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}
