using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BehaviorsAndTriggers.Views.SampleOne
{
    public partial class TestSampleOne : ContentPage
    {
        public TestSampleOne()
        {
            InitializeComponent();
            var screenHeight = (App.screenHeight * 1) / 100;
            var screenWidth = (App.screenWidth) / 100;



            gridHolder.HeightRequest = (screenHeight * 30);

        }
    }
}
