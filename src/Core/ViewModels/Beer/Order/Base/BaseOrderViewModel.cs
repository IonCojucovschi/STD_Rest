//
//  BaseOrderViewModel.cs
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
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Resources.Colors;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Beer.Order
{
    public abstract class BaseOrderViewModel : ProjectNavigationBaseViewModel
    {
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Back;

        public string TableNumber { get; set; }

        public virtual ICrossCellViewHolder<IOrderContent> CellModel { get; protected set; }

        [CrossView]
        public IListView ListView { get; set; }

        [CrossView]
        public IView BackroundContent { get; set; }

        public override void UpdateData()
        {
            base.UpdateData();

            CellModel = new OrderListBaseCell(this);

            BackroundContent?.SetBackgroundColor(ColorConstants.BackroundContent);

            ListView?.SetBackgroundColor(ColorConstants.BackroundContent);

            LoadListItems();
        }

        private void LoadListItems()
        {
            ListView?.UpdateDataSource(OrderManager.Instance.GetItem());
        }

        public class OrderListBaseCell : ICrossCellViewHolder<IOrderContent>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public OrderListBaseCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IImage CategoryImage { get; set; }


            [CrossView]
            public IText ItemNameText { get; set; }

            [CrossView]
            public IText QuantityText { get; set; }

            [CrossView]
            public IText PriceText { get; set; }

            public void Bind(IOrderContent model)
            {
                CellContentRootView?.SetBackgroundColor(ColorConstants.BackroundCell, 5);

                CategoryImage?.SetImageFromUrl(model.ImagePath);

                if (!ItemNameText.IsNull())
                {
                    ItemNameText.Text = model.OrderName;
                    ItemNameText?.SetTextColor(ColorConstants.WhiteColor);
                    ItemNameText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                }

                if (!PriceText.IsNull())
                {
                    PriceText.Text = "€" + model.Price * Convert.ToInt32(model.Quantity);
                    PriceText?.SetTextColor(ColorConstants.SelectorHome);
                    PriceText?.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                }

                if (QuantityText.IsNull()) return;
                QuantityText.Text = model.Quantity + " pcs";
                QuantityText?.SetTextColor(ColorConstants.WhiteColor);
                QuantityText?.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
            }

            public void OnCreate() { }
        }
    }
}
