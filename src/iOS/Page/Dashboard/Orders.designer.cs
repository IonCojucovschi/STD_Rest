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
    [Register ("Orders")]
    partial class Orders
    {
        [Outlet]
        UIKit.UITableView TableView { get; set; }


        [Outlet]
        UIKit.UIView viewBackroundContent { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }

            if (viewBackroundContent != null) {
                viewBackroundContent.Dispose ();
                viewBackroundContent = null;
            }
        }
    }
}