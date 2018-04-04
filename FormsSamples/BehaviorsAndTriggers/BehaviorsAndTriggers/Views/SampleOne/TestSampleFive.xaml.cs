using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BehaviorsAndTriggers.Views.SampleOne
{
    public partial class TestSampleFive : ContentPage
    {
        public TestSampleFive()
        {
            InitializeComponent();


            var screenHeight = (App.screenHeight * 1) / 100;
            var screenWidth = (App.screenWidth) / 100;


            /*
            entryUserName.Focused += EntryFocused;
            entryUserPassword.Focused += EntryFocused;
            entryUserMobile.Focused += EntryFocused;
            entryUserEMail.Focused += EntryFocused;

            entryUserName.HeightRequest = (screenHeight * 5);
            entryUserPassword.HeightRequest = (screenHeight * 5);
            entryUserMobile.HeightRequest = (screenHeight * 5);
            entryUserEMail.HeightRequest = (screenHeight * 5);

            labelUserName.HeightRequest = (screenHeight * 5);
            labelUserPassword.HeightRequest = (screenHeight * 5);
            labelUserMobile.HeightRequest = (screenHeight * 5);
            labelUserEMail.HeightRequest = (screenHeight * 5);
            */

            ceViewUserName.entry.Focused += EntryFocused;

            gridHolder.HeightRequest = (screenHeight * 50);

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
                Navigation.PopModalAsync();
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
                var element = (CustomEntry)sender;

                if(element.Placeholder.Contains("Name"))
                {
                    ceViewUserName.image.IsVisible = false;
                    ceViewUserName.label.IsVisible = false;
                }
                /*
                if (element.Placeholder.Contains("Name"))
                {
                    labelUserName.IsVisible = false;
                    imageUserName.IsVisible = false;
                }
                else if (element.Placeholder.Contains("Password"))
                {
                    labelUserPassword.IsVisible = false;
                    imageUserPassword.IsVisible = false;
                }
                else if (element.Placeholder.Contains("Mobile"))
                {
                    labelUserMobile.IsVisible = false;
                    imageUserMobile.IsVisible = false;
                }
                else if (element.Placeholder.Contains("Email"))
                {
                    labelUserEMail.IsVisible = false;
                    imageUserEMail.IsVisible = false;
                }
                else
                {

                }
                */
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void SubmitClicked(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(ceViewUserName.entry.Text))
                {
                    ceViewUserName.label.TextColor = Color.Red;
                    ceViewUserName.label.Text = "User Name cannot be null";
                    ceViewUserName.label.IsVisible = true;
                    ceViewUserName.image.IsVisible = true;
                }
                /*
                if (string.IsNullOrEmpty(entryUserName.Text))
                {
                    labelUserName.TextColor = Color.Red;
                    labelUserName.Text = "User Name cannot be null";
                    imageUserName.IsVisible = true;
                    labelUserName.IsVisible = true;
                }
                else if (string.IsNullOrEmpty(entryUserPassword.Text))
                {
                    labelUserPassword.TextColor = Color.Red;
                    labelUserPassword.Text = "User Password cannot be null";
                    labelUserPassword.IsVisible = true;
                    imageUserPassword.IsVisible = true;
                }
                else if (string.IsNullOrEmpty(entryUserMobile.Text))
                {
                    //labelUserMobile.TextColor = Color.Red;
                    //labelUserMobile.Text = "Mobile number cannot be null";
                    //labelUserMobile.IsVisible = true;
                    imageUserMobile.IsVisible = true;
                }
                else if (string.IsNullOrEmpty(entryUserEMail.Text))
                {
                    //labelUserEMail.TextColor = Color.Red;
                    //labelUserEMail.Text = "Email Id cannot be null";
                    //labelUserEMail.IsVisible = true;
                    imageUserEMail.IsVisible = true;
                }
                else
                {

                }
                */

                /*
                if (string.IsNullOrEmpty(entryUserName.Text))
                {
                    labelUserName.TextColor = Color.Red;
                    labelUserName.Text = "User Name cannot be null";
                    imageUserName.IsVisible = true;
                    labelUserName.IsVisible = true;
                }
                if (string.IsNullOrEmpty(entryUserPassword.Text))
                {
                    labelUserPassword.TextColor = Color.Red;
                    labelUserPassword.Text = "User Password cannot be null";
                    labelUserPassword.IsVisible = true;
                    imageUserPassword.IsVisible = true;
                }
                if (string.IsNullOrEmpty(entryUserMobile.Text))
                {
                    labelUserMobile.TextColor = Color.Red;
                    labelUserMobile.Text = "Mobile number cannot be null";
                    labelUserMobile.IsVisible = true;
                    imageUserMobile.IsVisible = true;
                }
                if (string.IsNullOrEmpty(entryUserEMail.Text))
                {
                    labelUserEMail.TextColor = Color.Red;
                    labelUserEMail.Text = "Email Id cannot be null";
                    labelUserEMail.IsVisible = true;
                    imageUserEMail.IsVisible = true;
                }
                */
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
