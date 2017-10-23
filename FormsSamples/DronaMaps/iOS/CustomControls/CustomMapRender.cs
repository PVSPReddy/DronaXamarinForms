using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using FMS;
using FMS.iOS;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRender))]
namespace FMS.iOS
{
    public class CustomMapRender : MapRenderer
    {
        public CustomMapRender() { }

        UIView customPinView;
        List<CustomPin> customPins;

        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                if (nativeMap != null)
                {
                    nativeMap.RemoveAnnotations(nativeMap.Annotations);
                    nativeMap.GetViewForAnnotation = null;
                }
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                var nativeMap = Control as MKMapView;
                customPins = formsMap.customPins;

                nativeMap.GetViewForAnnotation = GetViewForAnnotation;
            }
        }

        MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation is MKUserLocation)
                return null;

            var anno = annotation as MKPointAnnotation;
            if (customPins != null && !(customPins.Count <= 0))
            {
                var customPin = GetCustomPin(anno);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                annotationView = mapView.DequeueReusableAnnotation(customPin.pinId);
                if (annotationView == null)
                {
                    annotationView = new CustomMKAnnotationView(annotation, customPin.pinId)
                    {
                        Image = UIImage.FromFile("RyderMapPin.png"),
                        CalloutOffset = new CGPoint(0, 0),
                    };
                    ((CustomMKAnnotationView)annotationView).Id = customPin.pinId;
                }
                annotationView.CanShowCallout = true;
            }
            return annotationView;
        }

        CustomPin GetCustomPin(MKPointAnnotation annotation)
        {
            var position = new Position(annotation.Coordinate.Latitude, annotation.Coordinate.Longitude);
            return customPins.FirstOrDefault(pin => pin.pin.Position == position);
        }
    }

    public class CustomMKAnnotationView : MKAnnotationView
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public CustomMKAnnotationView(IMKAnnotation annotation, string id) : base(annotation, id)
        {
        }
    }
}