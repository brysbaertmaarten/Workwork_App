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
    public partial class AddContactInfoView : MvxViewController<AddContactInfoViewModel>
    {
        public AddContactInfoView (IntPtr handle) : base (handle)
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
        }
    }
}