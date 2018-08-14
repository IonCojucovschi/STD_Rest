// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace iOS
{
    [Register ("SideMenuView")]
    partial class SideMenuView
    {
        [Outlet]
        UIKit.UIImageView imgMenu { get; set; }


        [Outlet]
        UIKit.UITableView TableView { get; set; }


        [Outlet]
        UIKit.UIView viewContainer { get; set; }


        [Outlet]
        UIKit.UIView viewRoot { get; set; }


        [Outlet]
        UIKit.UIView viewTouchAreMenu { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgMenu != null) {
                imgMenu.Dispose ();
                imgMenu = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }

            if (viewContainer != null) {
                viewContainer.Dispose ();
                viewContainer = null;
            }

            if (viewRoot != null) {
                viewRoot.Dispose ();
                viewRoot = null;
            }

            if (viewTouchAreMenu != null) {
                viewTouchAreMenu.Dispose ();
                viewTouchAreMenu = null;
            }
        }
    }
}