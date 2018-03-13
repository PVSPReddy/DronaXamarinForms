using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BehaviorsAndTriggers.Views.SampleOne
{
    public partial class TestSampleTwo : ContentPage
    {
        public TestSampleTwo()
        {
            InitializeComponent();
            var screenHeight = (App.screenHeight * 1) / 100;
            var screenWidth = (App.screenWidth) / 100;

            entryUserName.Focused += EntryFocused;
            entryUserPassword.Focused += EntryFocused;
            entryUserMobile.Focused += EntryFocused;
            entryUserEMail.Focused += EntryFocused;


            //gridHolder.HeightRequest = (screenHeight * 50);
        }

        private void BackTapped(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void NextTapped(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new TestSampleThree());
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void EntryFocused(object sender, FocusEventArgs e)
        {
            try
            {
                var element = (Entry)sender;
                if (element.Placeholder.Contains("Name"))
                {
                    labelUserName.IsVisible = false;
                }
                else if (element.Placeholder.Contains("Password"))
                {
                    labelUserPassword.IsVisible = false;
                }
                else if (element.Placeholder.Contains("Mobile"))
                {
                    labelUserMobile.IsVisible = false;
                }
                else if (element.Placeholder.Contains("Email"))
                {
                    labelUserEMail.IsVisible = false;
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void SubmitClicked(object sender, EventArgs e)
        {
            try
            {
                //Device.BeginInvokeOnMainThread( async () =>
                //{
                    if (string.IsNullOrEmpty(entryUserName.Text))
                    {
                        labelUserName.Text = "User Name cannot be null";
                        labelUserName.IsVisible = true;
                        labelUserName.TextColor = Color.Red;
                    }
                    if (string.IsNullOrEmpty(entryUserPassword.Text))
                    {
                        labelUserPassword.IsVisible = true;
                        labelUserPassword.TextColor = Color.Red;
                        labelUserPassword.Text = "User Password cannot be null";
                    }
                    if (string.IsNullOrEmpty(entryUserMobile.Text))
                    {
                        labelUserMobile.Text = "Mobile number cannot be null";
                        labelUserMobile.IsVisible = true;
                        labelUserMobile.TextColor = Color.Red;
                    }
                    if (string.IsNullOrEmpty(entryUserEMail.Text))
                    {
                        labelUserEMail.TextColor = Color.Red;
                        labelUserEMail.Text = "Email Id cannot be null";
                        labelUserEMail.IsVisible = true;
                    }
                    /*
                    if (string.IsNullOrEmpty(entryUserName.Text))
                    {
                        labelUserName.TextColor = Color.Red;
                        labelUserName.Text = "User Name cannot be null";
                        labelUserName.IsVisible = true;
                    }
                    else if(string.IsNullOrEmpty(entryUserPassword.Text))
                    {
                        labelUserPassword.TextColor = Color.Red;
                        labelUserPassword.Text = "User Password cannot be null";
                        labelUserPassword.IsVisible = true;
                    }
                    else if (string.IsNullOrEmpty(entryUserMobile.Text))
                    {
                        labelUserMobile.TextColor = Color.Red;
                        labelUserMobile.Text = "Mobile number cannot be null";
                        labelUserMobile.IsVisible = true;
                    }
                    else if (string.IsNullOrEmpty(entryUserEMail.Text))
                    {
                        labelUserEMail.TextColor = Color.Red;
                        labelUserEMail.Text = "Email Id cannot be null";
                        labelUserEMail.IsVisible = true;
                    }
                    else
                    {

                    }
                    */
                //});
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
