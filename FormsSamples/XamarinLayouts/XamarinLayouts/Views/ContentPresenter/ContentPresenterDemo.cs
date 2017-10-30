using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinLayouts
{
    public partial class ContentPresenterDemo : ContentPage
    {
        bool originalTemplate = true;
        ControlTemplate tealTemplate;
        ControlTemplate aquaTemplate;

        public ContentPresenterDemo()
        {
            InitializeComponent();
            tealTemplate = (ControlTemplate)Application.Current.Resources["TealTemplate"];
            aquaTemplate = (ControlTemplate)Application.Current.Resources["MaroonTemplate"];
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            originalTemplate = !originalTemplate;
            contentView.ControlTemplate = (originalTemplate) ? tealTemplate : aquaTemplate;
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
                Navigation.PushModalAsync(new StackLayoutDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
