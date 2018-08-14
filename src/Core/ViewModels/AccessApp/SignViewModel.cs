//
// SplashViewModel.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2017 Songurov Fiodor
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Core.Helpers;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Core.Extensions;
using Core.Resources.Page;

namespace Core.ViewModels
{
    public class SignViewModel : ProjectBaseViewModel
    {
        [CrossView]
        public IImage LogoImage { get; protected set; }

        [CrossView]
        public IImage BackroundImage { get; protected set; }

        [CrossView]
        public IImage PasswordWatchImage { get; protected set; }


        [CrossView]
        public IText EmailPlaceholderText { get; protected set; }

        [CrossView]
        public IText EmailText { get; protected set; }

        [CrossView]
        public IView EmailLineText { get; protected set; }


        [CrossView]
        public IText PasswordPlaceholderText { get; protected set; }

        [CrossView]
        public IText PasswordText { get; protected set; }

        [CrossView]
        public IView PasswordLineText { get; protected set; }


        [CrossView]
        public IText PasswordForgotText { get; protected set; }


        [CrossView]
        public IText SignInText { get; protected set; }


        [CrossView]
        public IText RegistrationDontAccountText { get; protected set; }

        [CrossView]
        public IText SignUpText { get; protected set; }

        [CrossView]
        public IText ConnectFacebookText { get; protected set; }

        [CrossView]
        public IImage ConnectFacebookImage { get; protected set; }

        [CrossView]
        public IView FacebookContent { get; set; }

        public override void UpdateData()
        {
            base.UpdateData();
            InitViews();
        }

        private void InitViews()
        {
            LogoImage?.SetImageFromResource(DrawableConstants.LogoIcon);
            BackroundImage?.SetImageFromResource(DrawableConstants.SignBackround);

            if (PasswordWatchImage != null)
            {
                PasswordWatchImage?.SetImageFromResource(DrawableConstants.ShowPassword);
                PasswordWatchImage.SetImageColorFilter(ColorConstants.ButtonGray);

                PasswordWatchImage.Click -= ShowPasswordContent;
                PasswordWatchImage.Click += ShowPasswordContent;
            }

            if (EmailPlaceholderText != null)
            {
				EmailPlaceholderText.Text = RSign.SignEmailText;
                EmailPlaceholderText.SetFont(FontsConstant.RobotoRegular, FontsConstant.Size15);
                EmailPlaceholderText.SetTextColor(ColorConstants.ButtonGray);
            }

            if (EmailText != null)
            {
                EmailText.SetTextColor(ColorConstants.WhiteColor);
                EmailText.SetCursorColor(ColorConstants.SelectorHome);

                EmailText.Focus -= LineEmail;
                EmailText.Focus += LineEmail;
                EmailText.SetFont(FontsConstant.RobotoRegular, FontsConstant.Size16);
            }

            EmailLineText?.SetBackgroundColor(ColorConstants.WhiteColor);

            if (PasswordPlaceholderText != null)
            {
				PasswordPlaceholderText.Text = RSign.SignPasswordText;
                PasswordPlaceholderText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size15);
                PasswordPlaceholderText.SetTextColor(ColorConstants.ButtonGray);
            }

            if (PasswordText != null)
            {
                PasswordText.SetTextColor(ColorConstants.WhiteColor);
                PasswordText.SetSecure(InputType.Password);
                PasswordText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size16);
                PasswordText.SetCursorColor(ColorConstants.SelectorHome);

                PasswordText.Focus -= LinePassword;
                PasswordText.Focus += LinePassword;
            }

            PasswordLineText?.SetBackgroundColor(ColorConstants.WhiteColor);

            if (PasswordForgotText != null)
            {
				PasswordForgotText.Text = RSign.SignForgotText;
                PasswordForgotText.SetTextColor(ColorConstants.WhiteColor);
                PasswordForgotText.SetFont(FontsConstant.RobotoRegular, FontsConstant.Size15);
            }

            if (SignInText != null)
            {
				SignInText.Text = RSign.SignSignInText.ToUpperInvariant();
                SignInText.SetTextColor(ColorConstants.WhiteColor);
                SignInText.SetBackgroundColor(ColorConstants.SelectorHome);
                SignInText.SetSelectedColor(ColorConstants.WhiteColor);
                SignInText.SetFont(FontsConstant.RobotoBold, FontsConstant.Size14);
            }

            if (RegistrationDontAccountText != null)
            {
				RegistrationDontAccountText.Text =RSign.SignNotHaveAccount;
                RegistrationDontAccountText.SetTextColor(ColorConstants.WhiteColor);
                RegistrationDontAccountText.SetFont(FontsConstant.RobotoRegular, FontsConstant.Size15);
            }

            if (SignUpText != null)
            {
				SignUpText.Text = RSign.SignSignUpText;
                SignUpText.SetTextColor(ColorConstants.SelectorHome);
                SignUpText.SetFont(FontsConstant.RobotoRegular, FontsConstant.Size15);

                SignUpText.Click -= SignUp_Click;
                SignUpText.Click += SignUp_Click;
            }

            if (ConnectFacebookText != null)
            {
				ConnectFacebookText.Text = RSign.SignWithFacebook.ToUpperInvariant();
                ConnectFacebookText.SetTextColor(ColorConstants.WhiteColor);
                ConnectFacebookText.SetBackgroundColor(ColorConstants.BlueFacebookColor);
                ConnectFacebookText.SetSelectedColor(ColorConstants.WhiteColor);
                ConnectFacebookText.SetFont(FontsConstant.MontserratBold, FontsConstant.Size12);
            }

            ConnectFacebookImage?.SetImageFromResource(DrawableConstants.FacebookLogo);
            FacebookContent?.SetBackgroundColor(ColorConstants.BlueFacebookColor);
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            this.GoPage(PageConstants.PageNameCreateAccount);
        }

        private void LineEmail()
        {
            PasswordLineText?.SetBackgroundColor(ColorConstants.WhiteColor);
            EmailLineText?.SetBackgroundColor(ColorConstants.SelectorHome);
        }

        private void LinePassword()
        {
            PasswordLineText?.SetBackgroundColor(ColorConstants.SelectorHome);
            EmailLineText?.SetBackgroundColor(ColorConstants.WhiteColor);
        }

        private void ShowPasswordContent(object sender, EventArgs e)
        {
            if (!PasswordText.IsSecure)
            {
                PasswordText.SetSecure(InputType.Password);
                PasswordWatchImage.SetImageColorFilter(ColorConstants.ButtonGray);
                PasswordText.SetFont(FontsConstant.RobotoRegular, FontsConstant.Size16);
            }
            else
            {
                PasswordText.SetSecure(InputType.Password);
                PasswordWatchImage.SetImageColorFilter(ColorConstants.WhiteColor);
                PasswordText.SetFont(FontsConstant.RobotoRegular, FontsConstant.Size16);
            }
        }
    }
}