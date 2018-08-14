// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace iOS.Views.Window.Menu.Cell
{
    [Register ("MenuViewCell")]
    partial class MenuViewCell
    {
        [Outlet]
        UIKit.UIImageView imgMenu { get; set; }


        [Outlet]
        UIKit.UIView viewLine { get; set; }


        [Outlet]
        UIKit.UIView viewRoot { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgMenu != null) {
                imgMenu.Dispose ();
                imgMenu = null;
            }

            if (viewLine != null) {
                viewLine.Dispose ();
                viewLine = null;
            }

            if (viewRoot != null) {
                viewRoot.Dispose ();
                viewRoot = null;
            }
        }
    }
}