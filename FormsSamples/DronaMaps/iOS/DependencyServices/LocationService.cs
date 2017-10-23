using System;
using CoreLocation;
using FMS.iOS;
using Xamarin.Forms;
using System.Threading.Tasks;
using Foundation;
using UIKit;

[assembly: Dependency(typeof(LocationService))]
namespace FMS.iOS
{
    public class LocationEventArgs : EventArgs, ILocationEventArgs
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    public class LocationService : ILocationService
    {
        public event EventHandler<ILocationEventArgs> locationObtained;
        CLAuthorizationChangedEventArgs ex;
        public async void ObtainMyLocation()
        {
            try
            {
                CLLocationManager locationManager = new CLLocationManager();
                locationManager.DesiredAccuracy = CLLocation.AccuracyBest;
                locationManager.DistanceFilter = CLLocationDistance.FilterNone;

                locationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
                     {
                         CLLocation[] locations = e.Locations;
                         string strLocation = locations[locations.Length - 1].Coordinate.Latitude.ToString();
                         strLocation = strLocation + "," + locations[locations.Length - 1].Coordinate.Longitude.ToString();
                         LocationEventArgs args = new LocationEventArgs();
                         args.latitude = locations[locations.Length - 1].Coordinate.Latitude;
                         args.longitude = locations[locations.Length - 1].Coordinate.Longitude;
                         locationObtained(this, args);
                     };
                locationManager.AuthorizationChanged += (object sender, CLAuthorizationChangedEventArgs e) =>
                {
                    ex = e;
                    if (e.Status == CLAuthorizationStatus.AuthorizedWhenInUse)
                    {
                        locationManager.StartUpdatingLocation();
                    }
                    else if (e.Status == CLAuthorizationStatus.Denied || e.Status == CLAuthorizationStatus.Restricted)
                    {
                        locationManager.StopUpdatingLocation();
                        HomeMap.homeMap.startPageLoading(false);
                        //_currentLocation = null;
                    }
                    else if (e.Status == CLAuthorizationStatus.AuthorizedAlways)
                    {
                        locationManager.StartUpdatingLocation();
                    }
                };
                if (ex == null)
                {
                    locationManager.RequestWhenInUseAuthorization();
                }
                else
                {
                    HomeMap.homeMap.ShallStartGPS();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void OpenGPSSettings()
        {
            try
            {
                if (ex != null)
                {
                    if (ex.Status == CLAuthorizationStatus.Denied || ex.Status == CLAuthorizationStatus.Restricted)
                    {

                        var settingsString = UIKit.UIApplication.OpenSettingsUrlString;
                        var url = new NSUrl(settingsString);
                        UIApplication.SharedApplication.OpenUrl(url);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}