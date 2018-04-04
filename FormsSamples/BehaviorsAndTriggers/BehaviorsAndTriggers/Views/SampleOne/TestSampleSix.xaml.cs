using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BehaviorsAndTriggers.Views.SampleOne
{
    public partial class TestSampleSix : ContentPage
    {
        public TestSampleSix()
        {
            InitializeComponent();

            var screenHeight = (App.screenHeight * 1) / 100;
            var screenWidth = (App.screenWidth) / 100;

            ceViewUserName.entry.Placeholder = "Enter User Name";
            ceViewUserPassword.entry.Placeholder = "Enter User Password";
            ceViewUserMobile.entry.Placeholder = "Enter User Mobile";
            ceViewUserEmail.entry.Placeholder = "Enter User Email Id";


            ceViewUserName.entry.Focused += EntryFocused;
            ceViewUserPassword.entry.Focused += EntryFocused;
            ceViewUserMobile.entry.Focused += EntryFocused;
            ceViewUserEmail.entry.Focused += EntryFocused;

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

                if (element.Placeholder.Contains("Name"))
                {
                }

                if (element.Placeholder.Contains("Name"))
                {
                    ceViewUserName.mainHolder.BackgroundColor = Color.Yellow;
                    ceViewUserName.image.IsVisible = false;
                }
                else if (element.Placeholder.Contains("Password"))
                {
                    ceViewUserPassword.mainHolder.BackgroundColor = Color.Yellow;
                    ceViewUserPassword.image.IsVisible = false;
                }
                else if (element.Placeholder.Contains("Mobile"))
                {
                    ceViewUserMobile.mainHolder.BackgroundColor = Color.Yellow;
                    ceViewUserMobile.image.IsVisible = false;
                }
                else if (element.Placeholder.Contains("Email"))
                {
                    ceViewUserEmail.mainHolder.BackgroundColor = Color.Yellow;
                    ceViewUserEmail.image.IsVisible = false;
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

        private void SubmitClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ceViewUserName.entry.Text))
                {
                    //ceViewUserName.label.TextColor = Color.Red;
                    //ceViewUserName.label.Text = "User Name cannot be null";
                    //ceViewUserName.label.IsVisible = true;
                    ceViewUserName.mainHolder.BackgroundColor = Color.Red;
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


                if (string.IsNullOrEmpty(ceViewUserName.entry.Text))
                {
                    ceViewUserName.mainHolder.BackgroundColor = Color.Red;
                    ceViewUserName.image.IsVisible = true;
                }
                if (string.IsNullOrEmpty(ceViewUserPassword.entry.Text))
                {
                    ceViewUserPassword.mainHolder.BackgroundColor = Color.Red;
                    ceViewUserPassword.image.IsVisible = true;
                }
                if (string.IsNullOrEmpty(ceViewUserMobile.entry.Text))
                {
                    ceViewUserMobile.mainHolder.BackgroundColor = Color.Red;
                    ceViewUserMobile.image.IsVisible = true;
                }
                if (string.IsNullOrEmpty(ceViewUserEmail.entry.Text))
                {
                    ceViewUserEmail.mainHolder.BackgroundColor = Color.Red;
                    ceViewUserEmail.image.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
