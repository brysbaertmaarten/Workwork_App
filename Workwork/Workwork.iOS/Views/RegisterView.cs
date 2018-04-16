using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Workwork.Core.Services;
using Workwork.Core.ViewModels;
using Workwork.Functions.Models;
using Workwork.iOS.Converters;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class RegisterView : MvxViewController<RegisterViewModel>
    {
        public RegisterView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            MvxFluentBindingDescriptionSet<RegisterView, RegisterViewModel> set = new MvxFluentBindingDescriptionSet<RegisterView, RegisterViewModel>(this);

            set.Bind(lblFirstName).To(vm => vm.Account.FirstName);
            set.Bind(lblLastName).To(vm => vm.Account.LastName);
            set.Bind(lblUsername).To(vm => vm.Account.UserName);
            set.Bind(lblPassword).To(vm => vm.Account.Password);
            set.Bind(lblRepeatPassword).To(vm => vm.RepeatPassword);
            set.Bind(btnRegister).To(vm => vm.AddAccount);
            set.Bind(lblErrorMessage).To(vm => vm.Error);

            set.Apply();
        }



    }
}