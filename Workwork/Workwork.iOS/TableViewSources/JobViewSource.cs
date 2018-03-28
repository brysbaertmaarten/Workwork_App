using Foundation;
using MvvmCross.Binding.iOS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Workwork.iOS.TableViewSources
{
    public class JobViewSource : MvxTableViewSource
    {
        public JobViewSource(UITableView tableView) : base(tableView)
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            try
            {
                var cell = (JobTableCell)tableView.DequeueReusableCell(JobTableCell.Identifier, indexPath);
                return cell;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
