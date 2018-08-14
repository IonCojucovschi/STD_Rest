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
    [Register ("OrderTable")]
    partial class OrderTable
    {
        [Outlet]
        UIKit.UIImageView imgChangeTable { get; set; }


        [Outlet]
        UIKit.UILabel lblChangeText { get; set; }


        [Outlet]
        UIKit.UILabel lblConfirm { get; set; }


        [Outlet]
        UIKit.UILabel lblTableNr { get; set; }


        [Outlet]
        UIKit.UILabel lblTableNrValue { get; set; }


        [Outlet]
        UIKit.UITableView TableView { get; set; }


        [Outlet]
        UIKit.UIView viewContent { get; set; }


        [Outlet]
        UIKit.UIView viewTableNr { get; set; }


        [Outlet]
        UIKit.UIView viewTouchAreChange { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgChangeTable != null) {
                imgChangeTable.Dispose ();
                imgChangeTable = null;
            }

            if (lblChangeText != null) {
                lblChangeText.Dispose ();
                lblChangeText = null;
            }

            if (lblConfirm != null) {
                lblConfirm.Dispose ();
                lblConfirm = null;
            }

            if (lblTableNr != null) {
                lblTableNr.Dispose ();
                lblTableNr = null;
            }

            if (lblTableNrValue != null) {
                lblTableNrValue.Dispose ();
                lblTableNrValue = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }

            if (viewContent != null) {
                viewContent.Dispose ();
                viewContent = null;
            }

            if (viewTableNr != null) {
                viewTableNr.Dispose ();
                viewTableNr = null;
            }

            if (viewTouchAreChange != null) {
                viewTouchAreChange.Dispose ();
                viewTouchAreChange = null;
            }
        }
    }
}