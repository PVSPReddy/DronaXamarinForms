using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XamarinViews
{
    public partial class MapViewDemo : ContentPage
    {
        public MapViewDemo()
        {
            InitializeComponent();
            Position devRabbitPositionOnMap = new Position(17.428617, 78.433135);
            MapSpan mapSPanForDevrabbit = MapSpan.FromCenterAndRadius(devRabbitPositionOnMap, Distance.FromMiles(0.3));
            Pin PinDevrabbit = new Pin()
            {
                Id = "Software Company",
                Label = "DevRabbit It Solutions pvt. Ltd.",
                Address = " 8-2-268/R/5, Arora Colony Rd, Sri Nagar, Sagar Society, Sri Nagar Colony, Aurora Colony, Banjara Hills, Hyderabad, Telangana 500073",
                Position = devRabbitPositionOnMap,
                Type = PinType.Place
            };
            mapMap.Pins.Add(PinDevrabbit);
            mapMap.MoveToRegion(mapSPanForDevrabbit);
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
                App.Current.MainPage = new LabelDemo();
                //Navigation.PushModalAsync(new LabelDemo(), false);
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
                Navigation.PushModalAsync(new ListView_SearchBar(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
