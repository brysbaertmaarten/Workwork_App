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
    public partial class MyJobView : MvxTableViewController<MyJobViewModel>
    {
        public MyJobView (IntPtr handle) : base (handle)
        {
        }

        private MyJobViewSource _myJobViewSource;
        public override void ViewDidLoad()
        {
            _myJobViewSource = new MyJobViewSource(this.TableView);
            base.ViewDidLoad();

            this.TableView.Source = _myJobViewSource;
            this.TableView.ReloadData();

            MvxFluentBindingDescriptionSet<MyJobView, MyJobViewModel> set = new MvxFluentBindingDescriptionSet<MyJobView, MyJobViewModel>(this);
            set.Bind(_myJobViewSource).To(vm => vm.Jobs);
            set.Bind(_myJobViewSource).For(src => src.SelectionChangedCommand).To(vm => vm.NavigateToDetailCommand);
            set.Bind(_myJobViewSource).For(s => s.RemoveRowCommand).To(vm => vm.RemoveWineCommand);

            set.Apply();
        }
    }
}