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
	[Register ("EventDetails")]
	partial class EventDetails
	{
		[Outlet]
		UIKit.UIImageView imgBackround { get; set; }

		[Outlet]
		UIKit.UIImageView imgDate { get; set; }

		[Outlet]
		UIKit.UIImageView imgMain { get; set; }

		[Outlet]
		UIKit.UIImageView imgSeparator { get; set; }

		[Outlet]
		UIKit.UILabel lblDate { get; set; }

		[Outlet]
		UIKit.UILabel lblDesc { get; set; }

		[Outlet]
		UIKit.UILabel lblHour { get; set; }

		[Outlet]
		UIKit.UILabel lblTitle { get; set; }

		[Outlet]
		UIKit.UITextView txtDesc { get; set; }

		[Outlet]
		UIKit.UIView viewTinImageBackround { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgBackround != null) {
				imgBackround.Dispose ();
				imgBackround = null;
			}

			if (imgDate != null) {
				imgDate.Dispose ();
				imgDate = null;
			}

			if (imgMain != null) {
				imgMain.Dispose ();
				imgMain = null;
			}

			if (imgSeparator != null) {
				imgSeparator.Dispose ();
				imgSeparator = null;
			}

			if (lblDate != null) {
				lblDate.Dispose ();
				lblDate = null;
			}

			if (lblHour != null) {
				lblHour.Dispose ();
				lblHour = null;
			}

			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}

			if (txtDesc != null) {
				txtDesc.Dispose ();
				txtDesc = null;
			}

			if (viewTinImageBackround != null) {
				viewTinImageBackround.Dispose ();
				viewTinImageBackround = null;
			}

			if (lblDesc != null) {
				lblDesc.Dispose ();
				lblDesc = null;
			}
		}
	}
}
