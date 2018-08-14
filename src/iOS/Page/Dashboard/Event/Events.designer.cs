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
	[Register ("Events")]
	partial class Events
	{
		[Outlet]
		UIKit.UICollectionView CollectionView { get; set; }

		[Outlet]
		UIKit.UICollectionView CollectionViewSubTag { get; set; }

		[Outlet]
		UIKit.UIImageView imgLeft { get; set; }

		[Outlet]
		UIKit.UIImageView imgRight { get; set; }

		[Outlet]
		UIKit.UIImageView imgSort { get; set; }

		[Outlet]
		UIKit.UILabel lblMonth { get; set; }

		[Outlet]
		UIKit.UILabel lblMonthOrDay { get; set; }

		[Outlet]
		UIKit.UITableView TableView { get; set; }

		[Outlet]
		UIKit.UIView viewContentBackround { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CollectionView != null) {
				CollectionView.Dispose ();
				CollectionView = null;
			}

			if (CollectionViewSubTag != null) {
				CollectionViewSubTag.Dispose ();
				CollectionViewSubTag = null;
			}

			if (imgSort != null) {
				imgSort.Dispose ();
				imgSort = null;
			}

			if (lblMonth != null) {
				lblMonth.Dispose ();
				lblMonth = null;
			}

			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}

			if (viewContentBackround != null) {
				viewContentBackround.Dispose ();
				viewContentBackround = null;
			}

			if (lblMonthOrDay != null) {
				lblMonthOrDay.Dispose ();
				lblMonthOrDay = null;
			}

			if (imgLeft != null) {
				imgLeft.Dispose ();
				imgLeft = null;
			}

			if (imgRight != null) {
				imgRight.Dispose ();
				imgRight = null;
			}
		}
	}
}
