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
	[Register ("FeedbackGive")]
	partial class FeedbackGive
	{
		[Outlet]
		UIKit.UICollectionView CollectionView { get; set; }

		[Outlet]
		UIKit.UIImageView imgService { get; set; }

		[Outlet]
		UIKit.UILabel lblConfirm { get; set; }

		[Outlet]
		UIKit.UILabel lblService { get; set; }

		[Outlet]
		UIKit.UILabel lblTitle { get; set; }

		[Outlet]
		UIKit.UIView viewBackroundService { get; set; }

		[Outlet]
		UIKit.UIView viewContent { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CollectionView != null) {
				CollectionView.Dispose ();
				CollectionView = null;
			}

			if (imgService != null) {
				imgService.Dispose ();
				imgService = null;
			}

			if (lblConfirm != null) {
				lblConfirm.Dispose ();
				lblConfirm = null;
			}

			if (lblService != null) {
				lblService.Dispose ();
				lblService = null;
			}

			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}

			if (viewBackroundService != null) {
				viewBackroundService.Dispose ();
				viewBackroundService = null;
			}

			if (viewContent != null) {
				viewContent.Dispose ();
				viewContent = null;
			}
		}
	}
}
