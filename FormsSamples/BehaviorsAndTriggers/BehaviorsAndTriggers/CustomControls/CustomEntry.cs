using System;
using Xamarin.Forms;

namespace BehaviorsAndTriggers
{
	public class CustomEntry : Entry
	{
		public CustomEntry()
		{
			//TextColor = Color.FromHex("#282828");
			//PlaceholderColor = Color.FromHex("#282828");
		}


		public static readonly BindableProperty CustomFontFamilyProperty = BindableProperty.Create(propertyName: "CustomFontFamily", returnType: typeof(string), declaringType: typeof(CustomEntry), defaultValue: default(string));
		public string CustomFontFamily { get; set; }

		public static readonly BindableProperty CustomFontSizeProperty = BindableProperty.Create(propertyName: "CustomFontSize", returnType: typeof(float), declaringType: typeof(CustomEntry), defaultValue: default(float));
		public float CustomFontSize { get; set; }

		public static readonly BindableProperty IsCustomPasswordProperty = BindableProperty.Create(propertyName: "IsCustomPassword", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
		public bool IsCustomPassword { get; set; }

        public static readonly BindableProperty CustomEntryTypeProperty = BindableProperty.Create(propertyName: "CustomEntryType", returnType: typeof(string), declaringType: typeof(CustomEntry), defaultValue: default(string));
        public string CustomEntryType { get; set; }
	}
}

