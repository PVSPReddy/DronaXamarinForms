using System;
namespace FMS
{
	public interface ILocationService
	{
		void OpenGPSSettings();
		void ObtainMyLocation();
		event EventHandler<ILocationEventArgs> locationObtained;
	}
	public interface ILocationEventArgs
	{
		double latitude { get; set; }
		double longitude { get; set; }
	}
}
