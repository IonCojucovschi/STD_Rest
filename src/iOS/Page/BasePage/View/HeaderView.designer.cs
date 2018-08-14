// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace iOS.Storyboard
{
    [Register ("HeaderView")]
    partial class HeaderView
    {
        [Outlet]
        UIKit.UIImageView imgLeft { get; set; }


        [Outlet]
        UIKit.UIImageView imgRight { get; set; }


        [Outlet]
        UIKit.UILabel lblCounterShop { get; set; }


        [Outlet]
        UIKit.UILabel lblTitle { get; set; }


        [Outlet]
        UIKit.UIView viewClickLeft { get; set; }


        [Outlet]
        UIKit.UIView viewClickRight { get; set; }


        [Outlet]
        UIKit.UIView viewLine { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgLeft != null) {
                imgLeft.Dispose ();
                imgLeft = null;
            }

            if (imgRight != null) {
                imgRight.Dispose ();
                imgRight = null;
            }

            if (lblCounterShop != null) {
                lblCounterShop.Dispose ();
                lblCounterShop = null;
            }

            if (lblTitle != null) {
                lblTitle.Dispose ();
                lblTitle = null;
            }

            if (viewClickLeft != null) {
                viewClickLeft.Dispose ();
                viewClickLeft = null;
            }

            if (viewClickRight != null) {
                viewClickRight.Dispose ();
                viewClickRight = null;
            }

            if (viewLine != null) {
                viewLine.Dispose ();
                viewLine = null;
            }
        }
    }
}