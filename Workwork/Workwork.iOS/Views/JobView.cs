using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Workwork.Core.ViewModels;
using Workwork.iOS.TableViewSources;

namespace Workwork.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class JobView : MvxTableViewController<JobViewModel>
    {

        public JobView(IntPtr handle) : base(handle)
        {
        }

        private JobViewSource _jobViewSource;
        public override void ViewDidLoad()
        {
            _jobViewSource = new JobViewSource(this.TableView);
            base.ViewDidLoad();

            this.TableView.Source = _jobViewSource;
            this.TableView.ReloadData();

            MvxFluentBindingDescriptionSet<JobView, JobViewModel> set = new MvxFluentBindingDescriptionSet<JobView, JobViewModel>(this);
            set.Bind(_jobViewSource).To(vm => vm.Jobs);
        }
    }
}