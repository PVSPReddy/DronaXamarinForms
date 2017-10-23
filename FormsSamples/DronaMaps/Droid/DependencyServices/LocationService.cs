using System;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using FMS.Droid;
using Xamarin.Forms;

[assembly : Dependency(typeof(LocationService))]
namespace FMS.Droid
{
	public class LocationEventArgs : EventArgs, ILocationEventArgs
	{
		public double latitude { get; set; }
		public double longitude { get; set; }
	}

	public class LocationService : Java.Lang.Object, ILocationService, ILocationListener
	{
		LocationManager locationManager;
		public event EventHandler<ILocationEventArgs> locationObtained;

		public void ObtainMyLocation()
		{
			locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
			if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == true)
			{
				locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 0, 0, this);
			}
			else
			{
				HomeMap.homeMap.ShallStartGPS();
			} 

		}

		public void OpenGPSSettings()
		{
			try
			{
				HomeMap.homeMap.startPageLoading(false);
				Intent callGPSSettingIntent = new Intent(global::Android.Provider.Settings.ActionLocationSourceSettings);
				Forms.Context.StartActivity(callGPSSettingIntent);
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public void OnLocationChanged(Location location)
		{
			if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == true)
			{
				if (location != null)
				{
					LocationEventArgs args = new LocationEventArgs();
					args.latitude = location.Latitude;
					args.longitude = location.Longitude;
					locationObtained(this, args);
				}
			}
			else
			{
				//HomeMap.homeMap.ShallStartGPS();
			}
		}

		public void OnProviderDisabled(string provider)
		{
		}

		public void OnProviderEnabled(string provider)
		{
		}

		public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
		{
		}
	}
}