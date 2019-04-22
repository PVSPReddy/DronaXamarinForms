using System;
using FireBaseTestPOC.iOS.CustomControls;
using FireBaseTestPOC.Views;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly : ExportRenderer(typeof(DynamicGridPage), typeof(IOSPageOrientationRender))]
namespace FireBaseTestPOC.iOS.CustomControls
{
    public class IOSPageOrientationRender : PageRenderer
    {
        public IOSPageOrientationRender(){ }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.LandscapeLeft)), new NSString("orientation"));
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Portrait)), new NSString("orientation"));
        }
    }
}

