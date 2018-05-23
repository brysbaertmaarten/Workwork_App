using CoreLocation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using System.Diagnostics;
using Workwork.Core.ViewModels;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class AddLocationView : MvxViewController<AddLocationViewModel>
    {
        public object ReverseGeoCodingLocation { get; private set; }

        public AddLocationView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<AddLocationView, AddLocationViewModel> set = new MvxFluentBindingDescriptionSet<AddLocationView, AddLocationViewModel>(this);

            set.Bind(txtCity).To(vm => vm.Location.City);
            set.Bind(txtCountry).To(vm => vm.Location.Country);
            set.Bind(txtNumber).To(vm => vm.Location.Number);
            set.Bind(txtStreet).To(vm => vm.Location.Street);
            set.Bind(btnNext).To(vm => vm.Next);
            btnMyLocation.TouchUpInside += (sender, ea) =>
            {
                GetAddress();
            };

            set.Apply();  
        }

        //als user gebruik maakt van de location button
        public void GetAddress()
        {
            var myVM = this.ViewModel as AddLocationViewModel;
            if (myVM != null)
            {
                //permissie vragen aan gebruiker voor locatie
                CLLocationManager locationManager = new CLLocationManager();
                locationManager.RequestWhenInUseAuthorization();

                CLLocation loc = locationManager.Location;
                ReverseGeocodeToConsoleAsync(loc);

                async void ReverseGeocodeToConsoleAsync(CLLocation location)
                {
                    var geoCoder = new CLGeocoder();
                    var placemarks = await geoCoder.ReverseGeocodeLocationAsync(location);

                    txtCity.Text = placemarks[0].PostalAddress.City;
                    myVM.Location.City = placemarks[0].PostalAddress.City;
                    txtCountry.Text = placemarks[0].PostalAddress.Country;
                    myVM.Location.Country = placemarks[0].PostalAddress.Country;
                    txtStreet.Text = placemarks[0].PostalAddress.Street;
                    myVM.Location.Street = placemarks[0].PostalAddress.Street;
                }
            }
        }
    }
}