using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinLayouts
{
    public partial class AbsoluteLayoutDemo : ContentPage
    {
        public AbsoluteLayoutDemo()
        {
            InitializeComponent();

            showPopup.Clicked += (object sender, EventArgs e) =>
            {
                try
                {
                    popupStack.IsVisible = true;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            hidePopup.Clicked += (object sender, EventArgs e) =>
            {
                try
                {
                    popupStack.IsVisible = false;
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
                Navigation.PushModalAsync(new RelativeLayoutDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}
