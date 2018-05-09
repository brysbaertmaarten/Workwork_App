// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Workwork.iOS
{
    [Register ("JobView")]
    partial class JobView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar searchbar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (searchbar != null) {
                searchbar.Dispose ();
                searchbar = null;
            }
        }
    }
}