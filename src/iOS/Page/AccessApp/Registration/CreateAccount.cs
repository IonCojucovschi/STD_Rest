// This file has been autogenerated from a class added in the UI designer.

using System;
using iOS.Page.BasePage;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using UIKit;

namespace iOS.Storyboard
{
    public partial class CreateAccount : BasePageNavigation<CreateAccountViewModel>
    {
        public CreateAccount(IntPtr handle) : base(handle) { }
    }

    partial class CreateAccount
    {
        [CrossView(nameof(CreateAccountViewModel.BackroundImage))]
        UIImageView view1 => imgBackround;

        [CrossView(nameof(CreateAccountViewModel.TitleText))]
        UILabel view2 => lblTitle;

        [CrossView(nameof(CreateAccountViewModel.SignUpText))]
        UILabel view3 => lblSignUp;



        [CrossView(nameof(CreateAccountViewModel.EmailPlaceholderText))]
        UILabel view4 => lblEmail;

        [CrossView(nameof(CreateAccountViewModel.EmailText))]
        UITextField view5 => txtEmail;

        [CrossView(nameof(CreateAccountViewModel.EmailLineText))]
        UIView view6 => viewEmail;


        [CrossView(nameof(CreateAccountViewModel.PasswordPlaceholderText))]
        UILabel view7 => lblPassword;

        [CrossView(nameof(CreateAccountViewModel.PasswordText))]
        UITextField view8 => txtPassword;

        [CrossView(nameof(CreateAccountViewModel.PasswordLineText))]
        UIView view9 => viewPassword;


        [CrossView(nameof(CreateAccountViewModel.PasswordRepeatPlaceholderText))]
        UILabel view10 => lblRepeatPassword;

        [CrossView(nameof(CreateAccountViewModel.PasswordRepeatText))]
        UITextField view11 => txtRepeatPassword;

        [CrossView(nameof(CreateAccountViewModel.PasswordRepeatLineText))]
        UIView view12 => viewrepeatPassword;

        [CrossView(nameof(CreateAccountViewModel.NotePolicyText))]
        UILabel view13 => lbl1;

    }
}
