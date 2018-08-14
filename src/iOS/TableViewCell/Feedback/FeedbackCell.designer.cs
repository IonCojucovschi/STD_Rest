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
	[Register ("FeedbackCell")]
	partial class FeedbackCell
	{
		[Outlet]
		UIKit.UIImageView imgCategory { get; set; }

		[Outlet]
		UIKit.UIImageView imgStatus { get; set; }

		[Outlet]
		UIKit.UILabel lblCategory { get; set; }

		[Outlet]
		UIKit.UILabel lblServiceName { get; set; }

		[Outlet]
		UIKit.UILabel lblStatus1 { get; set; }

		[Outlet]
		UIKit.UILabel lblStatus2 { get; set; }

		[Outlet]
		UIKit.UIView mainCell { get; set; }

		[Outlet]
		UIKit.UIView viewProcent { get; set; }

		[Outlet]
		UIKit.UIView viewProcent20 { get; set; }

		[Outlet]
		UIKit.UIView viewProcent40 { get; set; }

		[Outlet]
		UIKit.UIView viewProcent60 { get; set; }

		[Outlet]
		UIKit.UIView viewProcent80 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgCategory != null) {
				imgCategory.Dispose ();
				imgCategory = null;
			}

			if (imgStatus != null) {
				imgStatus.Dispose ();
				imgStatus = null;
			}

			if (lblCategory != null) {
				lblCategory.Dispose ();
				lblCategory = null;
			}

			if (lblServiceName != null) {
				lblServiceName.Dispose ();
				lblServiceName = null;
			}

			if (lblStatus1 != null) {
				lblStatus1.Dispose ();
				lblStatus1 = null;
			}

			if (lblStatus2 != null) {
				lblStatus2.Dispose ();
				lblStatus2 = null;
			}

			if (mainCell != null) {
				mainCell.Dispose ();
				mainCell = null;
			}

			if (viewProcent != null) {
				viewProcent.Dispose ();
				viewProcent = null;
			}

			if (viewProcent20 != null) {
				viewProcent20.Dispose ();
				viewProcent20 = null;
			}

			if (viewProcent40 != null) {
				viewProcent40.Dispose ();
				viewProcent40 = null;
			}

			if (viewProcent60 != null) {
				viewProcent60.Dispose ();
				viewProcent60 = null;
			}

			if (viewProcent80 != null) {
				viewProcent80.Dispose ();
				viewProcent80 = null;
			}
		}
	}
}
