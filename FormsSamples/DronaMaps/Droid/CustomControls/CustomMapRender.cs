using System;
using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using FMS;
using FMS.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRender))]
namespace FMS.Droid
{
    public class CustomMapRender : MapRenderer
    {
        public CustomMapRender() { }

        List<CustomPin> customPins;
        bool isDrawn;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {

            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.customPins;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                var map = ((MapView)Control).Map;
#pragma warning restore CS0618 // Type or member is obsolete


                map.UiSettings.ZoomControlsEnabled = false;
                map.UiSettings.MyLocationButtonEnabled = false;

                if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
                {
                    NativeMap.Clear();
                    if (customPins != null && !(customPins.Count <= 0))
                    {
                        foreach (var pin in customPins)
                        {
                            var marker = new MarkerOptions();
                            marker.SetPosition(new LatLng(pin.pin.Position.Latitude, pin.pin.Position.Longitude));
                            marker.SetTitle(pin.pin.Label);
                            marker.SetSnippet(pin.pin.Address);
                            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.RyderMapPin));

                            NativeMap.AddMarker(marker);
                        }
                    }
                    isDrawn = true;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
            if (changed)
            {
                isDrawn = false;
            }
        }
    }
}

