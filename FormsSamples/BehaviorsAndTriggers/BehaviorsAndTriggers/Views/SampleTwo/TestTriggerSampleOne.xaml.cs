using System;
using System.Collections.Generic;

using Xamarin.Forms;


//here we are using all the triggers that are declared in these pages only we are
//not getting any data from outside except the behaviors.

namespace BehaviorsAndTriggers.Views.SampleTwo
{
    public partial class TestTriggerSampleOne : ContentPage
    {
        public TestTriggerSampleOne()
        {
            InitializeComponent();
        }

        private void BackTapped(object sender, EventArgs e)
        {
            try
            {
                //Navigation.PopModalAsync();
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
                //Navigation.PushModalAsync(new TestSampleFive());
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
                //var element = (Entry)sender;
                //if (element.Placeholder.Contains("Name"))
                //{
                //    labelUserName.IsVisible = false;
                //    imageUserName.IsVisible = false;
                //}
                //else if (element.Placeholder.Contains("Password"))
                //{
                //    labelUserPassword.IsVisible = false;
                //    imageUserPassword.IsVisible = false;
                //}
                //else if (element.Placeholder.Contains("Mobile"))
                //{
                //    labelUserMobile.IsVisible = false;
                //    imageUserMobile.IsVisible = false;
                //}
                //else if (element.Placeholder.Contains("Email"))
                //{
                //    labelUserEMail.IsVisible = false;
                //    imageUserEMail.IsVisible = false;
                //}
                //else
                //{

                //}
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

                //if (string.IsNullOrEmpty(entryUserName.Text))
                //{
                //    labelUserName.TextColor = Color.Red;
                //    labelUserName.Text = "User Name cannot be null";
                //    imageUserName.IsVisible = true;
                //    labelUserName.IsVisible = true;
                //}
                //if (string.IsNullOrEmpty(entryUserPassword.Text))
                //{
                //    labelUserPassword.TextColor = Color.Red;
                //    labelUserPassword.Text = "User Password cannot be null";
                //    labelUserPassword.IsVisible = true;
                //    imageUserPassword.IsVisible = true;
                //}
                //if (string.IsNullOrEmpty(entryUserMobile.Text))
                //{
                //    labelUserMobile.TextColor = Color.Red;
                //    labelUserMobile.Text = "Mobile number cannot be null";
                //    labelUserMobile.IsVisible = true;
                //    imageUserMobile.IsVisible = true;
                //}
                //if (string.IsNullOrEmpty(entryUserEMail.Text))
                //{
                //    labelUserEMail.TextColor = Color.Red;
                //    labelUserEMail.Text = "Email Id cannot be null";
                //    labelUserEMail.IsVisible = true;
                //    imageUserEMail.IsVisible = true;
                //}
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
