using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Workwork.Core.ViewModels;
using Workwork.Functions.Models;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class AddContactInfoView : MvxViewController<AddContactInfoViewModel>
    {
        public AddContactInfoView(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<AddContactInfoView, AddContactInfoViewModel> set = new MvxFluentBindingDescriptionSet<AddContactInfoView, AddContactInfoViewModel>(this);

            set.Bind(txtEmail).To(vm => vm.ContactInfo.Email);
            set.Bind(txtPhone).To(vm => vm.ContactInfo.PhoneNumber);
            set.Bind(btnSave).To(vm => vm.Save);

            set.Apply();

            GetPosition();
        }

        //krijg lat en long
        public void GetPosition()
        {
            var myVM = this.ViewModel as AddContactInfoViewModel;
            if (myVM != null)
            {
                //permissie vragen aan gebruiker voor locatie
                CLLocationManager locationManager = new CLLocationManager();
                locationManager.RequestWhenInUseAuthorization();

                //krijg lat en long op basis van adres string
                var searchRequest = new MKLocalSearchRequest();
                searchRequest.NaturalLanguageQuery = myVM.Location.ToString();
                searchRequest.Region = new MKCoordinateRegion(locationManager.Location.Coordinate, new MKCoordinateSpan(0.25, 0.25));
                var localSearch = new MKLocalSearch(searchRequest);
                localSearch.Start(delegate (MKLocalSearchResponse response, NSError error)
                {
                    if (response != null && error == null)
                    {
                        myVM.Location.Lat = response.MapItems[0].Placemark.Location.Coordinate.Latitude;
                        myVM.Location.Lon = response.MapItems[0].Placemark.Location.Coordinate.Longitude;
                    }
                    else
                    {
                        Console.WriteLine("local search error: {0}", error);
                    }
                });
            }
        }
    }
}