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
    [Register ("OrderBar")]
    partial class OrderBar
    {
        [Outlet]
        UIKit.UILabel lblOrderCode { get; set; }


        [Outlet]
        UIKit.UILabel lblOrderCodeValue { get; set; }


        [Outlet]
        UIKit.UITableView TableView { get; set; }


        [Outlet]
        UIKit.UIView viewContent { get; set; }


        [Outlet]
        UIKit.UIView viewNrBar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblOrderCode != null) {
                lblOrderCode.Dispose ();
                lblOrderCode = null;
            }

            if (lblOrderCodeValue != null) {
                lblOrderCodeValue.Dispose ();
                lblOrderCodeValue = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }

            if (viewContent != null) {
                viewContent.Dispose ();
                viewContent = null;
            }

            if (viewNrBar != null) {
                viewNrBar.Dispose ();
                viewNrBar = null;
            }
        }
    }
}