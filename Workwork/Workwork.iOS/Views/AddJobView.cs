using Foundation;
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
    }
}