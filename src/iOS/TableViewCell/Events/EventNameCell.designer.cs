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
	[Register ("EventNameCell")]
	partial class EventNameCell
	{
		[Outlet]
		UIKit.UIImageView imgEvent { get; set; }

		[Outlet]
		UIKit.UILabel lblDate2 { get; set; }

		[Outlet]
		UIKit.UILabel lblEventName { get; set; }

		[Outlet]
		UIKit.UILabel lblTime1 { get; set; }

		[Outlet]
		UIKit.UILabel lblTime2 { get; set; }

		[Outlet]
		UIKit.UIView mainCell { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgEvent != null) {
				imgEvent.Dispose ();
				imgEvent = null;
			}

			if (lblEventName != null) {
				lblEventName.Dispose ();
				lblEventName = null;
			}

			if (lblTime1 != null) {
				lblTime1.Dispose ();
				lblTime1 = null;
			}

			if (mainCell != null) {
				mainCell.Dispose ();
				mainCell = null;
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
