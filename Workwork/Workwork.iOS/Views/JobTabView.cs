using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Workwork.Core.ViewModels;
using Workwork.Shared.ViewModels;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class JobTabView : MvxTabBarViewController<JobTabViewModel>
    {
        private bool _constructed;
        public JobTabView (IntPtr handle) : base (handle)
        {
            _constructed = true;
            ViewDidLoad();
        }

        public override void ViewDidLoad()
        {
            if (!_constructed) return;
            base.ViewDidLoad();

            NavigationItem.RightBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            NavigationItem.SetHidesBackButton(true, false);

            UIBarButtonItem LogoutButton = new UIBarButtonItem
            {
                Title = "Logout"
            };

            NavigationItem.LeftBarButtonItem = LogoutButton;

            MvxFluentBindingDescriptionSet<JobTabView, JobTabViewModel> set = new MvxFluentBindingDescriptionSet<JobTabView, JobTabViewModel>(this);
            set.Bind(NavigationItem.RightBarButtonItem).To(vm => vm.NavigateToAddJobCommand);
            set.Bind(NavigationItem.LeftBarButtonItem).To(vm => vm.NavigateToLogoutCommand);
            set.Apply();

            CreateTabs();
        }

        private void CreateTabs()
        {
            var viewControllers = new UIViewController[]
            {
                CreateSingleTab("Jobs", ViewModel.JobVM),
                CreateSingleTab("My Jobs", ViewModel.MyJobVM)
            };

            ViewControllers = viewControllers;
            SelectedViewController = ViewControllers[0];
            NavigationItem.Title = SelectedViewController.Title;
            ViewControllerSelected += (o, e) =>
            {
                NavigationItem.Title = TabBar.SelectedItem.Title;
            };
        }

        private UIViewController CreateSingleTab(string tabName, MvxViewModel tabViewModel)
        {
            var viewController = this.CreateViewControllerFor(tabViewModel) as UIViewController;

            tabViewModel.Start();

            viewController.Title = tabName;
            viewController.TabBarItem = new UITabBarItem() { Title = tabName };

            return viewController;
        }
    }
}