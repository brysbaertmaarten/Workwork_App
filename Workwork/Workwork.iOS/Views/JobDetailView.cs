using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Workwork.Core.ViewModels;
using Workwork.Functions.Models;
using MapKit;
using CoreLocation;
using System.Collections.Generic;
using System.Diagnostics;
using Workwork.iOS.Converters;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class JobDetailView : MvxViewController<JobDetailViewModel>
    {
        public JobDetailView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<JobDetailView, JobDetailViewModel> set = this.CreateBindingSet<JobDetailView, JobDetailViewModel>();
            set.Bind(lblTitle).To(vm => vm.Job.Title);
            set.Bind(lblDescription).To(vm => vm.Job.Description);
            set.Bind(lblAddress).To(vm => vm.Job.Location);
            set.Bind(lblPayment).To(vm => vm.Job.Payment);
            set.Bind(lblPhone).To(vm => vm.Job.ContactInfo.PhoneNumber);
            set.Bind(lblEmail).To(vm => vm.Job.ContactInfo.Email);
            set.Bind(btnOpenMaps).To(vm => vm.LaunchMapsCommand);
            set.Bind(lblDate).To(vm => vm.Job.PostTime).WithConversion<DateToStringConverter>();

            set.Apply();

            var myVM = this.ViewModel as JobDetailViewModel;
            if (myVM != null)
            {
                CLLocationCoordinate2D jobLocation = new CLLocationCoordinate2D(myVM.Job.Location.Lat, myVM.Job.Location.Lon);

                //permissie vragen aan gebruiker voor locatie
                CLLocationManager locationManager = new CLLocationManager();
                locationManager.RequestWhenInUseAuthorization();

                //map settings
                mapView.ZoomEnabled = true;
                mapView.ScrollEnabled = true;
                mapView.MultipleTouchEnabled = true;

                //center map
                MKCoordinateRegion mapRegion = MKCoordinateRegion.FromDistance(jobLocation, 500, 500);
                mapView.CenterCoordinate = jobLocation;
                mapView.Region = mapRegion;

                //show userlocation
                mapView.ShowsUserLocation = true;

                //distance
                CLLocation jobLoc = new CLLocation(jobLocation.Latitude, jobLocation.Longitude);
                var distance = locationManager.Location.DistanceFrom(jobLoc);
                string distanceInKm = Math.Round((distance / 1000), 2).ToString() + " km";

                //show job location as annotation
                mapView.AddAnnotations(new MKPointAnnotation()
                {
                    Title = myVM.Job.Title, //aanpassen met jobnaam
                    Subtitle = distanceInKm, //aanpassen met afstand
                    Coordinate = jobLocation
                });
            }
        }
    }
}