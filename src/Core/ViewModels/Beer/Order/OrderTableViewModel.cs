//
//  OrderViewModel.cs
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
using System.Linq;
using System.Threading;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Page;
using Core.ViewModels.Beer.Order;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Beer
{
    public class OrderTableViewModel : BaseOrderPaymentViewModel
    {
        protected override string HeaderText => ROrderTable.OrderAtTable;

        [CrossView]
        public IView OrderBackround { get; set; }

        [CrossView]
        public IText ConfirmText { get; set; }


        [CrossView]
        public IText TableNrValueText { get; set; }

        [CrossView]
        public IText TableNrText { get; set; }

        [CrossView]
        public IText ChangeText { get; set; }

        [CrossView]
        public IImage ChangeImage { get; set; }

        [CrossView]
        public IView BackroundChange { get; set; }

        public override void UpdateData()
        {
            base.UpdateData();

            OrderBackround?.SetBackgroundColor(ColorConstants.BlackColor);

            BackroundContent?.SetBackgroundColor(ColorConstants.BackroundContent);
            ChangeImage?.SetImageFromResource(DrawableConstants.ChangeIcon);

            if (BackroundChange != null)
            {
                BackroundChange.Click -= Change_Click;
                BackroundChange.Click += Change_Click;

                BackroundChange?.SetBackgroundColor(ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent20), 5);
                BackroundChange?.SetSelectedColor(ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent70));
            }

            if (TableNrText != null)
            {
                TableNrText.Text = ROrderTable.TableNo;
                TableNrText.SetTextColor(ColorConstants.WhiteColor);
                TableNrText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
            }

            if (TableNrValueText != null)
            {
                TableNrValueText.Text = OrderManager.Instance.OrderType == OrderVisibility.Local ?
                                                TableNumber :
                                                OrderManager.Instance.CurrentOrderServer.Code;

                TableNrValueText.SetTextColor(ColorConstants.SelectorHome);
                TableNrValueText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size36);
            }

            if (ChangeText != null)
            {
                ChangeText.Text = ROrderTable.Change.ToUpperInvariant();
                ChangeText.SetTextColor(ColorConstants.WhiteColor);
                ChangeText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size10);
            }

            if (ConfirmText == null) return;

            if (OrderManager.Instance.OrderType == OrderVisibility.Local)
            {
                ConfirmText.Click -= ConfirmText_Click;
                ConfirmText.Click += ConfirmText_Click;
                ConfirmText.Text = ROrderTable.Confirm.ToUpperInvariant();
                ConfirmText.SetTextColor(ColorConstants.WhiteColor);
                ConfirmText.SetBackgroundColor(ColorConstants.SelectorHome);
                ConfirmText.SetSelectedColor(ColorConstants.SelectorHome.SelectorTransparence(ColorConstants.Procent50));
                ConfirmText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
            }
            else
            {
                ConfirmText.Text = "";
                ConfirmText.SetBackgroundColor(ColorConstants.BlackColor);
                ConfirmText.SetTextColor(ColorConstants.BlackColor);
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            this.GoPage(PageConstants.PageNameCode);
        }

        private void ConfirmText_Click(object sender, EventArgs e)
        {
            if (OrderManager.Instance.OrderType != OrderVisibility.Local ||
                !(OrderManager.Instance.GetItem().Sum(x => x.Price * Convert.ToInt32(x.Quantity)) > 0)) return;
            Show();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                OrderManager.Instance.AddOrder(Models.DTO.OrderType.Table, (obj) =>
                {
                    TableNumber = obj.ToString();
                    GetPayment?.Invoke(Verify);
                }, (obj) =>
                {
                    ShowError(obj);
                }, TableNumber);
            });
        }
    }
}
