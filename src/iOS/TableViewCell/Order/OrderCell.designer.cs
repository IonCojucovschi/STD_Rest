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
    [Register ("OrderCell")]
    partial class OrderCell
    {
        [Outlet]
        UIKit.UIImageView imgOrder { get; set; }


        [Outlet]
        UIKit.UIImageView imgOrderRemove { get; set; }


        [Outlet]
        UIKit.UILabel lblCounter { get; set; }


        [Outlet]
        UIKit.UILabel lblMinus { get; set; }


        [Outlet]
        UIKit.UILabel lblName { get; set; }


        [Outlet]
        UIKit.UILabel lblPlus { get; set; }


        [Outlet]
        UIKit.UILabel lblPrice { get; set; }


        [Outlet]
        UIKit.UIView mainRoot { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgOrder != null) {
                imgOrder.Dispose ();
                imgOrder = null;
            }

            if (imgOrderRemove != null) {
                imgOrderRemove.Dispose ();
                imgOrderRemove = null;
            }

            if (lblCounter != null) {
                lblCounter.Dispose ();
                lblCounter = null;
            }

            if (lblMinus != null) {
                lblMinus.Dispose ();
                lblMinus = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (lblPlus != null) {
                lblPlus.Dispose ();
                lblPlus = null;
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