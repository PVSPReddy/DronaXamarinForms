using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinLayouts
{
    public partial class GridDemo : ContentPage
    {

        public GridDemo()
        {
            InitializeComponent();
            bool isMobNoFine = false;
            #region for providing screen heights/widths dynamically for different screen/devices
            var screenHeight = (App.screenHeight * 1) / 100;
            var screenWidth = (App.screenWidth * 1) / 100;

            headerStack.HeightRequest = screenHeight * 9;
            backBtn.HeightRequest = screenHeight * 9;
            startPageBtn.HeightRequest = screenHeight * 9;
            nextBtn.HeightRequest = screenHeight * 9;
            #endregion

            entrymobilenumber.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
                    long i = -1;
                    var entry = sender as Entry;
                    isMobNoFine = Int64.TryParse(entry.Text, out i);
                    if (!(Int64.TryParse(entry.Text, out i)))
                    {
                        entrymobilenumber.TextColor = Color.Red;
                    }
                    else
                    {
                        entrymobilenumber.TextColor = Color.Default;
                        if (entry.Text.Length <= 10)
                        {
                            isMobNoFine = true;
                            entrymobilenumber.TextColor = Color.Default;
                        }
                        else
                        {
                            entrymobilenumber.TextColor = Color.Red;
                            isMobNoFine = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };

            Addbtn.Clicked += (object sender, EventArgs e) =>
            {
                if (string.IsNullOrEmpty(entryfirstname.Text))
                {
                    DisplayAlert("Alert", "First name field should not be empty", "Ok");
                }
                else if (string.IsNullOrEmpty(entrylastname.Text))
                {
                    DisplayAlert("Alert", "Last name field should not be empty", "Ok");
                }
                else if (string.IsNullOrEmpty(entrycomapanyname.Text))
                {
                    DisplayAlert("Alert", "Company name field should not be empty", "Ok");
                }
                else if (string.IsNullOrEmpty(entrydesignation.Text))
                {
                    DisplayAlert("Alert", "Designation field should not be empty", "Ok");
                }
                else if (string.IsNullOrEmpty(entrymobilenumber.Text))
                {
                    DisplayAlert("Alert", "Mobile number field should not be empty", "Ok");
                }
                else if (entrymobilenumber.Text.Length != 10 || isMobNoFine != true)
                {
                    DisplayAlert("Alert", "Enter a Valid Mobile Number", "Ok");
                }
                else if (string.IsNullOrEmpty(editoraddress.Text))
                {
                    DisplayAlert("Alert", "Address field should not be empty", "Ok");
                }
                else
                {
                    DisplayAlert("Alert", "Validation id successful", "Ok");
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
                Navigation.PushModalAsync(new AbsoluteLayoutDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}
