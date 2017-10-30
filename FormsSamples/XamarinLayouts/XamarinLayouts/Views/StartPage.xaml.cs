using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinLayouts
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            stackLayout.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushModalAsync(new StackLayoutDemo(), false);
            };
            gridLayout.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushModalAsync(new GridDemo(), false);
            };
            absLayout.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushModalAsync(new AbsoluteLayoutDemo(), false);
            };
            relativeLayout.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushModalAsync(new RelativeLayoutDemo(), false);
            };
            scrollView.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushModalAsync(new ScrollViewDemo(), false);
            };
            frame.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushModalAsync(new FrameDemo(), false);
            };
            contentPresenter.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushModalAsync(new ContentPresenterDemo(), false);
            };
            //scrollView.Clicked += (object sender, EventArgs e) => 
            //{
            //    Navigation.PushModalAsync(new ScrollViewDemo(), false);
            //};
        }

        void backBtnClicked(object sender, EventArgs e)
        {
            try
            {

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
                Navigation.PushModalAsync(new StackLayoutDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}
