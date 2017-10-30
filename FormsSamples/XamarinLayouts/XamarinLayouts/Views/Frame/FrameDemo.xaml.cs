using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinLayouts
{
    public partial class FrameDemo : ContentPage
    {
        public FrameDemo()
        {
            InitializeComponent();
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
                Navigation.PushModalAsync(new ContentPresenterDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
