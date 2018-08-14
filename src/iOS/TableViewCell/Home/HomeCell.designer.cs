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
    [Register ("HomeCell")]
    partial class HomeCell
    {
        [Outlet]
        UIKit.UIImageView imgName { get; set; }


        [Outlet]
        UIKit.UILabel lblName { get; set; }


        [Outlet]
        UIKit.UIView viewRootCell { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgName != null) {
                imgName.Dispose ();
                imgName = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (viewRootCell != null) {
                viewRootCell.Dispose ();
                viewRootCell = null;
            }
        }
    }
}