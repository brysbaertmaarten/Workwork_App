using Foundation;
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

        

    }
}