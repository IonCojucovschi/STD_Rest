//
//  CallViewModel.cs
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
using System.Threading;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Resources.Page;
using Core.ViewModels.Beer;
using Int.Core.Extensions;

namespace Core.ViewModels
{
    public class CallViewModel : BaseCodeViewModel
    {
        protected override string HeaderText => RCallView.CallWaiter;
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Menu;

        public override void UpdateData()
        {
            base.UpdateData();

            if (TitleText == null) return;
            TitleText.Text = "Read qr-code in order to call a waiter to your table";
            TitleText.SetFont(FontsConstant.RobotoBold, FontsConstant.Size18);
        }

        protected override void ConfirmTableText_Click(object sender, EventArgs e)
        {
            if (TableNrValueText.Text.IsNullOrWhiteSpace()) return;

            Show();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                OrderManager.Instance.AddNotification(TableNrValueText.Text, () =>
                {
                    this.GoPage(PageConstants.PageNameHome);
                }, (obj) => ShowError(obj));
            });
        }
    }
}
