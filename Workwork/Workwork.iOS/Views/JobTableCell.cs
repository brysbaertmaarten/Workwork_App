using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;
using UIKit;
using Workwork.Functions.Models;

namespace Workwork.iOS
{
    public partial class JobTableCell : MvxTableViewCell
    {
        internal static readonly NSString Identifier = new NSString("JobCell");

        public JobTableCell(IntPtr handle) : base(handle)
        {
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            MvxFluentBindingDescriptionSet<JobTableCell, Job> set = new MvxFluentBindingDescriptionSet<JobTableCell, Job>(this);
            set.Bind(TextLabel).To(job => job.Title);
            set.Bind(DetailTextLabel).To(job => job.Location.City);

            set.Apply();
        }
    }
}