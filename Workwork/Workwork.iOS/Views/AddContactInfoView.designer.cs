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
    [Register ("AddContactInfoView")]
    partial class AddContactInfoView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton txtSave { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (txtEmail != null) {
                txtEmail.Dispose ();
                txtEmail = null;
            }

            if (txtPhone != null) {
                txtPhone.Dispose ();
                txtPhone = null;
            }

            if (txtSave != null) {
                txtSave.Dispose ();
                txtSave = null;
            }
        }
    }
}