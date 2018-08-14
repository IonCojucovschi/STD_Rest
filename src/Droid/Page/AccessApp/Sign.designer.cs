//
//  Splash.designer.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2017 Songurov
//
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using Android.Views;
using Android.Widget;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class Sign
    {
		[CrossView(nameof(SignViewModel.BackroundImage))]
		[InjectView(Resource.Id.background_image)]
		protected ImageView BackroundImage { get; set; }

		[CrossView(nameof(SignViewModel.LogoImage))]
		[InjectView(Resource.Id.logo)]
		protected ImageView LogoImage { get; set; }

		[CrossView(nameof(SignViewModel.PasswordWatchImage))]
		[InjectView(Resource.Id.show_pasword)]
		protected ImageView PasswordWatchImage { get; set; }

		[CrossView(nameof(SignViewModel.EmailPlaceholderText))]
		[InjectView(Resource.Id.email_label)]
		protected TextView EmailPlaceholderText { get; set; }
		[CrossView(nameof(SignViewModel.EmailText))]
		[InjectView(Resource.Id.email_value)]
		protected EditText EmailText { get; set; }
		[CrossView(nameof(SignViewModel.EmailLineText))]
		[InjectView(Resource.Id.email_underline)]
		protected View EmailLineText { get; set; }



		[CrossView(nameof(SignViewModel.PasswordPlaceholderText))]
		[InjectView(Resource.Id.password_label)]
		protected TextView PasswordPlaceholderText { get; set; }
		[CrossView(nameof(SignViewModel.PasswordText))]
		[InjectView(Resource.Id.password_value)]
		protected EditText PasswordText { get; set; }
		[CrossView(nameof(SignViewModel.PasswordLineText))]
		[InjectView(Resource.Id.password_underline)]
		protected View PasswordLineText { get; set; }
             

		[CrossView(nameof(SignViewModel.PasswordForgotText))]
		[InjectView(Resource.Id.forgot_password)]
		protected TextView PasswordForgotText { get; set; }
		[CrossView(nameof(SignViewModel.SignInText))]
		[InjectView(Resource.Id.sign_in)]
		protected TextView SignInText { get; set; }
		[CrossView(nameof(SignViewModel.RegistrationDontAccountText))]
		[InjectView(Resource.Id.not_have_account_text)]
		protected TextView RegistrationDontAccountText { get; set; }
		[CrossView(nameof(SignViewModel.SignUpText))]
		[InjectView(Resource.Id.sign_up_text)]
		protected TextView SignUpText { get; set; }

		[CrossView(nameof(SignViewModel.ConnectFacebookImage))]
		[InjectView(Resource.Id.logo_facebook)]
		protected ImageView FacebookLogo { get; set; }
		[CrossView(nameof(SignViewModel.ConnectFacebookText))]
		[InjectView(Resource.Id.facebooktext)]
        protected TextView ConnectFacebook { get; set; }
		[CrossView(nameof(SignViewModel.FacebookContent))]
		[InjectView(Resource.Id.facebook_content)]
		protected LinearLayout FacebookContent { get; set; }
    }
}
