using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FMS
{
	/// <summary>
	/// This render is to remove map zoom and current location icons on maps
	/// </summary>
	public class CustomMap : Map
	{
		public CustomMap(){}
		public List<CustomPin> customPins { get; set; }
	}

	public class CustomPin
	{
		public string pinId { get; set; }
		public Pin pin { get; set; }
	}
}