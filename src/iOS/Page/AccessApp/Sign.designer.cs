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
	[Register ("Sign")]
	partial class Sign
	{
		[Outlet]
		UIKit.UIImageView imgBackround { get; set; }

		[Outlet]
		UIKit.UIImageView imgHide { get; set; }

		[Outlet]
		UIKit.UIImageView imgLogo { get; set; }

		[Outlet]
		UIKit.UILabel lblDont { get; set; }

		[Outlet]
		UIKit.UILabel lblEmailStatic { get; set; }

		[Outlet]
		UIKit.UILabel lblFacebook { get; set; }

		[Outlet]
		UIKit.UILabel lblForgotPassword { get; set; }

		[Outlet]
		UIKit.UILabel lblPassword { get; set; }

		[Outlet]
		UIKit.UILabel lblSignIn { get; set; }

		[Outlet]
		UIKit.UILabel lblSignUp { get; set; }

		[Outlet]
		UIKit.UITextField txtEmail { get; set; }

		[Outlet]
		UIKit.UITextField txtPassword { get; set; }

		[Outlet]
		UIKit.UIView viewEmail { get; set; }

		[Outlet]
		UIKit.UIView viewLinePassword { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgBackround != null) {
				imgBackround.Dispose ();
				imgBackround = null;
			}

			if (imgLogo != null) {
				imgLogo.Dispose ();
				imgLogo = null;
			}

			if (lblEmailStatic != null) {
				lblEmailStatic.Dispose ();
				lblEmailStatic = null;
			}

			if (txtEmail != null) {
				txtEmail.Dispose ();
				txtEmail = null;
			}

			if (viewEmail != null) {
				viewEmail.Dispose ();
				viewEmail = null;
			}

			if (lblPassword != null) {
				lblPassword.Dispose ();
				lblPassword = null;
			}

			if (txtPassword != null) {
				txtPassword.Dispose ();
				txtPassword = null;
			}

			if (viewLinePassword != null) {
				viewLinePassword.Dispose ();
				viewLinePassword = null;
			}

			if (imgHide != null) {
				imgHide.Dispose ();
				imgHide = null;
			}

			if (lblForgotPassword != null) {
				lblForgotPassword.Dispose ();
				lblForgotPassword = null;
			}

			if (lblDont != null) {
				lblDont.Dispose ();
				lblDont = null;
			}

			if (lblSignUp != null) {
				lblSignUp.Dispose ();
				lblSignUp = null;
			}

			if (lblSignIn != null) {
				lblSignIn.Dispose ();
				lblSignIn = null;
			}

			if (lblFacebook != null) {
				lblFacebook.Dispose ();
				lblFacebook = null;
			}
		}
	}
}
