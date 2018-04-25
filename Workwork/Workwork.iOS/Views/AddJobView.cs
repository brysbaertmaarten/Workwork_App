using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Workwork.Core.ViewModels;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class AddJobView : MvxViewController<AddJobViewModel>
    {
        public AddJobView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<AddJobView, AddJobViewModel> set = new MvxFluentBindingDescriptionSet<AddJobView, AddJobViewModel>(this);

            set.Bind(txtTitle).To(vm => vm.Job.Title);
            set.Bind(txtDescription).To(vm => vm.Job.Description);
            set.Bind(txtPayment).To(vm => vm.Job.Payment);
            set.Bind(btnNext).To(vm => vm.Next);

            set.Apply();
        }
    }
}