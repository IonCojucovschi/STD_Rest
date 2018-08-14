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
    [Register ("OrdersCell")]
    partial class OrdersCell
    {
        [Outlet]
        UIKit.UILabel lblDateTime { get; set; }


        [Outlet]
        UIKit.UILabel lblOrderId { get; set; }


        [Outlet]
        UIKit.UILabel lblTotalPrice { get; set; }


        [Outlet]
        UIKit.UILabel lblTypeOrder { get; set; }


        [Outlet]
        UIKit.UIView mainRoot { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblDateTime != null) {
                lblDateTime.Dispose ();
                lblDateTime = null;
            }

            if (lblOrderId != null) {
                lblOrderId.Dispose ();
                lblOrderId = null;
            }

            if (lblTotalPrice != null) {
                lblTotalPrice.Dispose ();
                lblTotalPrice = null;
            }

            if (lblTypeOrder != null) {
                lblTypeOrder.Dispose ();
                lblTypeOrder = null;
            }

            if (mainRoot != null) {
                mainRoot.Dispose ();
                mainRoot = null;
            }
        }
    }
}