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
	[Register ("EventCollectionSubTagCell")]
	partial class EventCollectionSubTagCell
	{
		[Outlet]
		UIKit.UIImageView imgBackroundDate { get; set; }

		[Outlet]
		UIKit.UIImageView imgEvent { get; set; }

		[Outlet]
		UIKit.UIImageView imgSeparator { get; set; }

		[Outlet]
		UIKit.UILabel lblDate { get; set; }

		[Outlet]
		UIKit.UILabel lblDate2 { get; set; }

		[Outlet]
		UIKit.UILabel lblName { get; set; }

		[Outlet]
		UIKit.UILabel lblTime2 { get; set; }

		[Outlet]
		UIKit.UIView mainView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgBackroundDate != null) {
				imgBackroundDate.Dispose ();
				imgBackroundDate = null;
			}

			if (imgEvent != null) {
				imgEvent.Dispose ();
				imgEvent = null;
			}

			if (imgSeparator != null) {
				imgSeparator.Dispose ();
				imgSeparator = null;
			}

			if (lblDate != null) {
				lblDate.Dispose ();
				lblDate = null;
			}

			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}

			if (mainView != null) {
				mainView.Dispose ();
				mainView = null;
			}

			if (lblDate2 != null) {
				lblDate2.Dispose ();
				lblDate2 = null;
			}

			if (lblTime2 != null) {
				lblTime2.Dispose ();
				lblTime2 = null;
			}
		}
	}
}
