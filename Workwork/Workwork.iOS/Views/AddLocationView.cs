using Foundation;
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
    }
}