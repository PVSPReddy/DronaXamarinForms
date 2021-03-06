﻿using System;
using System.Collections.Generic;
using FireBaseTestPOC.CustomControls;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class DynamicGridPage : ContentPage
    {
        #region for common code
        #region for Restricting orientation to landscape mode
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send<DynamicGridPage>(this, "LandScape");
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //MessagingCenter.Send<DynamicGridPage>(this, "Sensor");
            MessagingCenter.Send<DynamicGridPage>(this, "Portrait");
        }
        #endregion
        #endregion

        DynamicGrid grid;
        public DynamicGridPage()
        {
            InitializeComponent();
            grid = new DynamicGrid()
            {
                BackgroundColor = Color.Maroon,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            dynamicButtonsView.AddChildren(grid);
            dynamicButtonsView.HorizontalButtonClickedEvent += HorizontalButtonClicked;
            dynamicButtonsView.VerticalButtonClickedEvent += VerticalButtonClicked;
        }

        void BackButtonTapped(object sender, System.EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        private void HorizontalButtonClicked(object sender, CustomTapEventArgs e)
        {
            try
            {
                grid.AlterCells(EffectedSection.Column, e);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        private void VerticalButtonClicked(object sender, CustomTapEventArgs e)
        {
            try
            {
                grid.AlterCells(EffectedSection.Row, e);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }
    }
}
