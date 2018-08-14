//
//  CreateAccount.designer.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2018 Songurov Fiodor
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

using System;
using Android.Views;
using Android.Widget;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class CreateAccount
	{
        [CrossView(nameof(CreateAccountViewModel.BackroundImage))]
        [InjectView(Resource.Id.background_image)]
        protected ImageView BackroundImage { get; set; }

        [CrossView(nameof(CreateAccountViewModel.TitleText))]
        [InjectView(Resource.Id.create_account_text)]
        protected TextView TitleText { get; set; }

        protected TextView NoteTermText { get; set; }
        [CrossView(nameof(CreateAccountViewModel.NotePolicyText))]
        [InjectView(Resource.Id.privaci_polici)]
        protected TextView NotePolicyText { get; set; }
        
        [CrossView(nameof(CreateAccountViewModel.EmailPlaceholderText))]
        [InjectView(Resource.Id.email_label)]
        protected TextView EmailPlaceholderText { get; set; }
        [CrossView(nameof(CreateAccountViewModel.EmailText))]
        [InjectView(Resource.Id.email_value)]
        protected EditText EmailText { get; set; }
        [CrossView(nameof(CreateAccountViewModel.EmailLineText))]
        [InjectView(Resource.Id.email_underline)]
        protected View EmailLineText { get; set; }

        [CrossView(nameof(CreateAccountViewModel.PasswordPlaceholderText))]
        [InjectView(Resource.Id.password_label)]
        protected TextView PasswordPlaceholderText { get; set; }
        [CrossView(nameof(CreateAccountViewModel.PasswordText))]
        [InjectView(Resource.Id.pasword_value)]
        protected EditText PasswordText { get; set; }
        [CrossView(nameof(CreateAccountViewModel.PasswordLineText))]
        [InjectView(Resource.Id.password_underline)]
        protected View PasswordLineText { get; set; }
      
        [CrossView(nameof(CreateAccountViewModel.PasswordRepeatPlaceholderText))]
        [InjectView(Resource.Id.password_repeat_label)]
        protected TextView PasswordRepeatPlaceholderText { get; set; }
        [CrossView(nameof(CreateAccountViewModel.PasswordRepeatText))]
        [InjectView(Resource.Id.pasword_repeat_value)]
        protected EditText PasswordRepeatText { get; set; }
        [CrossView(nameof(CreateAccountViewModel.PasswordRepeatLineText))]
        [InjectView(Resource.Id.password_repeat_underline)]
        protected View PasswordRepeatLineText { get; set; }

        [CrossView(nameof(CreateAccountViewModel.SignUpText))]
        [InjectView(Resource.Id.sign_up_text)]
        protected TextView SignUpText { get; set; }
    }
}
