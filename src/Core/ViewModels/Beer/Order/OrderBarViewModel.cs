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

using Core.Helpers;
using Core.Helpers.Manager;
using Core.Resources.Colors;
using Core.Resources.Page;
using Core.ViewModels.Beer.Order;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Beer
{
    public class OrderBarViewModel : BaseOrderViewModel
    {
        protected override string HeaderText => ROrderBar.OrderAtBar;

        [CrossView]
        public IText OrderCode { get; set; }

        [CrossView]
        public IText OrderCodeValue { get; set; }

        [CrossView]
        public IView OrderBackround { get; set; }


        public override void UpdateData()
        {
            base.UpdateData();

            OrderBackround?.SetBackgroundColor(ColorConstants.BlackColor);

            if (OrderCode != null)
            {
                OrderCode.Text = ROrderBar.OrderCode;
                OrderCode.SetTextColor(ColorConstants.WhiteColor);
                OrderCode.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
            }

            if (OrderCodeValue == null) return;
            OrderCodeValue.Text = OrderManager.Instance.OrderType == OrderVisibility.Local ?
                                                TableNumber :
                                                OrderManager.Instance.CurrentOrderServer.Id.ToString();

            OrderCodeValue.SetTextColor(ColorConstants.SelectorHome);
            OrderCodeValue.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size36);
        }
    }
}
