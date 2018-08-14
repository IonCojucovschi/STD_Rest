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
    [Register ("OrderTableCell")]
    partial class OrderTableCell
    {
        [Outlet]
        UIKit.UIImageView imgOrder { get; set; }


        [Outlet]
        UIKit.UILabel lblCounter { get; set; }


        [Outlet]
        UIKit.UILabel lblName { get; set; }


        [Outlet]
        UIKit.UILabel lblPrice { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView mainRoot { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgOrder != null) {
                imgOrder.Dispose ();
                imgOrder = null;
            }

            if (lblCounter != null) {
                lblCounter.Dispose ();
                lblCounter = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (lblPrice != null) {
                lblPrice.Dispose ();
                lblPrice = null;
            }

            if (mainRoot != null) {
                mainRoot.Dispose ();
                mainRoot = null;
            }
        }
    }
}