using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using UIKit;

namespace Workwork.iOS.TableViewSources
{
    public class MyJobViewSource : MvxTableViewSource
    {
        public MyJobViewSource(UITableView tableView) : base(tableView)
        {
        }

        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    RemoveRowCommand.Execute(indexPath.Row);
                    break;
                case UITableViewCellEditingStyle.None: break;
            }
        }

        public IMvxCommand RemoveRowCommand { get; set; }

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