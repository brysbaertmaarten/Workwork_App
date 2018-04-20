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
    [Register ("AddLocationView")]
    partial class AddLocationView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnMyLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCountry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtStreet { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnMyLocation != null) {
                btnMyLocation.Dispose ();
                btnMyLocation = null;
            }

            if (txtCity != null) {
                txtCity.Dispose ();
                txtCity = null;
            }

            if (txtCountry != null) {
                txtCountry.Dispose ();
                txtCountry = null;
            }

            if (txtNumber != null) {
                txtNumber.Dispose ();
                txtNumber = null;
            }

            if (txtStreet != null) {
                txtStreet.Dispose ();
                txtStreet = null;
            }
        }
    }
}