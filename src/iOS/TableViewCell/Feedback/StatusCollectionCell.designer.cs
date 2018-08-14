// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iOS.Storyboard
{
	[Register ("StatusCollectionCell")]
	partial class StatusCollectionCell
	{
		[Outlet]
		UIKit.UIImageView imgStatus { get; set; }

		[Outlet]
		UIKit.UILabel lblStatus { get; set; }

		[Outlet]
		UIKit.UIView mainView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (mainView != null) {
				mainView.Dispose ();
				mainView = null;
			}

			if (imgStatus != null) {
				imgStatus.Dispose ();
				imgStatus = null;
			}

			if (lblStatus != null) {
				lblStatus.Dispose ();
				lblStatus = null;
			}
		}
	}
}
