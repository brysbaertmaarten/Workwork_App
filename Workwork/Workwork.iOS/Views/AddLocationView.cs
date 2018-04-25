using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Workwork.Core.ViewModels;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class AddLocationView : MvxViewController<AddLocationViewModel>
    {
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

            set.Apply();
        }
    }
}