using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Workwork.Core.ViewModels;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class LoginView : MvxViewController<LoginViewModel>
    {
        public LoginView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            MvxFluentBindingDescriptionSet<LoginView, LoginViewModel> set = new MvxFluentBindingDescriptionSet<LoginView, LoginViewModel>(this);

            set.Bind(txtPassword).To(vm => vm.Password);
            set.Bind(txtUsername).To(vm => vm.Username);
            set.Bind(btnLogin).To(vm => vm.LoginCommand);
            set.Bind(lblErrorMessage).To(vm => vm.Error);
            set.Bind(btnRegister).To(vm => vm.RegisterCommand);

            set.Apply();
        }
    }
}