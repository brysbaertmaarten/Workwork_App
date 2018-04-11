using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Workwork.Core.ViewModels;
using Workwork.Functions.Models;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class JobDetailView : MvxViewController<JobDetailViewModel>
    {
        public JobDetailView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<JobDetailView, JobDetailViewModel> set = this.CreateBindingSet<JobDetailView, JobDetailViewModel>();
            set.Bind(lblTitle).To(vm => vm.Job.Title);
            set.Bind(lblDescription).To(vm => vm.Job.Description);
            set.Bind(lblCity).To(vm => vm.Job.Location.City);
            set.Bind(lblStreet).To(vm => vm.Job.Location.Street);
            set.Bind(lblNumber).To(vm => vm.Job.Location.Number);
            set.Bind(lblPayment).To(vm => vm.Job.Payment);
            set.Bind(lblCountry).To(vm => vm.Job.Location.Country);
            set.Bind(lblPhone).To(vm => vm.Job.ContactInfo.PhoneNumber);
            set.Bind(lblEmail).To(vm => vm.Job.ContactInfo.Email);

            set.Apply();
        }
    }
}