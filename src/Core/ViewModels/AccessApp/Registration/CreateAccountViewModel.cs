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

using Core.Helpers;
using Core.Resources.Colors;
using Core.Resources.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels
{
    public class CreateAccountViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => string.Empty;
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Back;


        [CrossView]
        public IImage BackroundImage { get; protected set; }

        [CrossView]
        public IText TitleText { get; protected set; }

        [CrossView]
        public IText NotePolicyText { get; protected set; }


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
        public IText PasswordRepeatPlaceholderText { get; protected set; }

        [CrossView]
        public IText PasswordRepeatText { get; protected set; }

        [CrossView]
        public IView PasswordRepeatLineText { get; protected set; }


        [CrossView]
        public IText SignUpText { get; protected set; }


        public override void UpdateData()
        {
            base.UpdateData();

            BackroundImage?.SetBackgroundColor(ColorConstants.GrayCreateAccountColor);

            if (TitleText != null)
            {
                TitleText.Text = RCreate.CreateAccountText;
                TitleText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size34);
                TitleText.SetTextColor(ColorConstants.WhiteColor);
            }

            if (NotePolicyText != null)
            {
                NotePolicyText.Text = RCreate.CreateAgreeContentText;
                NotePolicyText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size12);
                NotePolicyText.SetTextColor(ColorConstants.WhiteColor);
                NotePolicyText.SetLinkAndStyle(new[] { RCreate.CreateTermsConditionText, RCreate.CreatePrivacyPolicyText },
                                               new[] { "www.facebook.com", "www.facebook.com" },
                                               "color:" + ColorConstants.SelectorHome + "; text-decoration: none;");
            }


            if (EmailPlaceholderText != null)
            {
                EmailPlaceholderText.Text = RSign.SignEmailText;
                EmailPlaceholderText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size15);
                EmailPlaceholderText.SetTextColor(ColorConstants.WhiteColor);
            }

            if (EmailText != null)
            {
                EmailText.SetTextColor(ColorConstants.WhiteColor);
                EmailText.SetFont(FontsConstant.OpenSansRegular);
                EmailText.SetCursorColor(ColorConstants.SelectorHome);

                EmailText.Focus -= LineEmail;
                EmailText.Focus += LineEmail;
            }

            EmailLineText?.SetBackgroundColor(ColorConstants.WhiteColor);

            if (PasswordPlaceholderText != null)
            {
                PasswordPlaceholderText.Text = RSign.SignPasswordText;
                PasswordPlaceholderText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size15);
                PasswordPlaceholderText.SetTextColor(ColorConstants.WhiteColor);
            }

            if (PasswordText != null)
            {
                PasswordText.SetTextColor(ColorConstants.WhiteColor);
                PasswordText.SetFont(FontsConstant.OpenSansRegular);
                PasswordText.SetCursorColor(ColorConstants.SelectorHome);
                PasswordText.SetSecure(InputType.Password);

                PasswordText.Focus -= LinePassword;
                PasswordText.Focus += LinePassword;
            }

            PasswordLineText?.SetBackgroundColor(ColorConstants.WhiteColor);

            if (PasswordRepeatPlaceholderText != null)
            {
                PasswordRepeatPlaceholderText.Text = RCreate.CreateRepeatPasswordText;
                PasswordRepeatPlaceholderText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size15);
                PasswordRepeatPlaceholderText.SetTextColor(ColorConstants.WhiteColor);
            }

            if (PasswordRepeatText != null)
            {
                PasswordRepeatText.SetTextColor(ColorConstants.WhiteColor);
                PasswordRepeatText.SetFont(FontsConstant.OpenSansRegular);
                PasswordRepeatText.SetCursorColor(ColorConstants.SelectorHome);
                PasswordText.SetSecure(InputType.Password);

                PasswordRepeatText.Focus -= LinePasswordRepeat;
                PasswordRepeatText.Focus += LinePasswordRepeat;
            }

            PasswordRepeatLineText?.SetBackgroundColor(ColorConstants.WhiteColor);

            if (SignUpText != null)
            {
                SignUpText.Text = RSign.SignSignUpText.ToUpperInvariant();
                SignUpText.SetTextColor(ColorConstants.WhiteColor);
                SignUpText.SetBackgroundColor(ColorConstants.SelectorHome);
                SignUpText.SetSelectedColor(ColorConstants.WhiteColor);
                SignUpText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size14);
            }
        }

        private void LineEmail()
        {
            EmailLineText?.SetBackgroundColor(ColorConstants.SelectorHome);
            PasswordLineText?.SetBackgroundColor(ColorConstants.WhiteColor);
            PasswordRepeatLineText?.SetBackgroundColor(ColorConstants.WhiteColor);
        }

        private void LinePassword()
        {
            PasswordLineText?.SetBackgroundColor(ColorConstants.SelectorHome);
            EmailLineText?.SetBackgroundColor(ColorConstants.WhiteColor);
            PasswordRepeatLineText?.SetBackgroundColor(ColorConstants.WhiteColor);
        }

        private void LinePasswordRepeat()
        {
            PasswordRepeatLineText?.SetBackgroundColor(ColorConstants.SelectorHome);
            PasswordLineText?.SetBackgroundColor(ColorConstants.WhiteColor);
            EmailLineText?.SetBackgroundColor(ColorConstants.WhiteColor);
        }
    }
}