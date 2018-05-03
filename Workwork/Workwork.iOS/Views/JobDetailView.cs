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

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class JobDetailView : MvxViewController<JobDetailViewModel>
    {
        public MKMapItem[] MapItems { get; set; }
        public JobDetailView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Test();

            MvxFluentBindingDescriptionSet<JobDetailView, JobDetailViewModel> set = this.CreateBindingSet<JobDetailView, JobDetailViewModel>();
            set.Bind(lblTitle).To(vm => vm.Job.Title);
            set.Bind(lblDescription).To(vm => vm.Job.Description);
            set.Bind(lblAddress).To(vm => vm.Job.Location);
            set.Bind(lblPayment).To(vm => vm.Job.Payment);
            set.Bind(lblPhone).To(vm => vm.Job.ContactInfo.PhoneNumber);
            set.Bind(lblEmail).To(vm => vm.Job.ContactInfo.Email);
            set.Bind(btnOpenMaps).To(vm => vm.LaunchMapsCommand);
            set.Apply();

            //permissie vragen aan gebruiker voor locatie
            CLLocationManager locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();

            //coordinate of job
            CLLocationCoordinate2D jobLocation = new CLLocationCoordinate2D(42.364260, -71.120824); //aanpassen met coordinaat van job

            //map settings (center map and region)
            mapView.ZoomEnabled = true;
            mapView.ScrollEnabled = true;
            mapView.MultipleTouchEnabled = true;
            CLLocationCoordinate2D mapCenter = jobLocation;
            MKCoordinateRegion mapRegion = MKCoordinateRegion.FromDistance(mapCenter, 200, 200);
            mapView.CenterCoordinate = mapCenter;
            mapView.Region = mapRegion;

            //show userlocation
            mapView.ShowsUserLocation = true;

            //show job location as annotation
            mapView.AddAnnotations(new MKPointAnnotation()
            {
                Title = "Job naam", //aanpassen met jobnaam
                Subtitle = "City", //aanpassen met city
                Coordinate = jobLocation
            });
        }

        //test
        public void Test()
        {
            List<MKMapItem> MapI;
            var searchRequest = new MKLocalSearchRequest();
            searchRequest.NaturalLanguageQuery = "stijn streuvelslaan 4 de pinte belgie";
            searchRequest.Region = new MKCoordinateRegion(mapView.UserLocation.Coordinate, new MKCoordinateSpan(0.25, 0.25));
            var localSearch = new MKLocalSearch(searchRequest);
            localSearch.Start(delegate (MKLocalSearchResponse response, NSError error) {
                if (response != null && error == null)
                {
                    this.MapItems = response.MapItems;
                    //MapI = new List<MKMapItem>(response.MapItems);
                }
                else
                {
                    Console.WriteLine("local search error: {0}", error);
                }
            });
        }
    }
}