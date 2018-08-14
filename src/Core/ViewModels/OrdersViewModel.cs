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
using System.Threading;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Resources.Colors;
using Core.Resources.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Beer
{
    public class OrdersViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => ROrders.OrdersHeader;

        [CrossView]
        public IListView ListView { get; protected set; }

        [CrossView]
        public IView BackroundContent { get; private set; }

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Menu;

        public virtual ICrossCellViewHolder<Core.Models.DTO.Order.Get.OrderModel> CellModel { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();

            OrderManager.Instance.OrderType = OrderVisibility.Server;


            CellModel = new OrdersListCell(this);

            LoadListItems();

            ListView?.SetBackgroundColor(ColorConstants.BackroundContent);
            BackroundContent?.SetBackgroundColor(ColorConstants.BackroundContent);
        }

        private void LoadListItems()
        {
            Show();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                OrderManager.Instance.GetOrder(data =>
                {
                    Hide();

                    ListView?.UpdateDataSource(data);
                    ListView?.RowCountLimit(7);

                }, err => ShowError(err));
            });
        }

        public class OrdersListCell : ICrossCellViewHolder<Core.Models.DTO.Order.Get.OrderModel>
        {
            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IText ItemTypeOrder { get; set; }

            [CrossView]
            public IText DateTimeText { get; set; }

            [CrossView]
            public IText PriceText { get; set; }

            [CrossView]
            public IText OrderIdText { get; set; }

            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public OrderViewModel CurrentViewModel => _baseViewModel as OrderViewModel;

            public OrdersListCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            public void Bind(Models.DTO.Order.Get.OrderModel model)
            {
                CellContentRootView?.SetBackgroundColor(ColorConstants.BackroundCell, 5);

                if (!ItemTypeOrder.IsNull())
                {
                    ItemTypeOrder.Text = model.Type == 1 ? @ROrderBar.OrderAtBar : ROrderTable.OrderAtTable;
                    ItemTypeOrder?.SetTextColor(ColorConstants.WhiteColor);
                    ItemTypeOrder.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                }

                if (!PriceText.IsNull())
                {
                    PriceText.Text = "€" + model.TotalAmount;
                    PriceText?.SetTextColor(ColorConstants.SelectorHome);
                    PriceText?.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                }

                if (!OrderIdText.IsNull())
                {
                    OrderIdText.Text = "#" + model.Id;
                    OrderIdText?.SetTextColor(ColorConstants.SelectorHome);
                    OrderIdText?.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size36);
                }

                if (DateTimeText.IsNull()) return;
                DateTimeText.Text = model.UpdatedAt.UnixTimeStampToDateTime().ToString("dd.MM.yyyy / hh:mm");
                DateTimeText?.SetTextColor(ColorConstants.WhiteColor);
                DateTimeText?.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size14);


                if (CellContentRootView.IsNull()) return;
                CellContentRootView.Tag = model;
                CellContentRootView.Click -= CellContentRootView_Click;
                CellContentRootView.Click += CellContentRootView_Click;
            }

            private void CellContentRootView_Click(object sender, EventArgs e)
            {
                if (!((sender as IView)?.Tag is Models.DTO.Order.Get.OrderModel data)) return;

                OrderManager.Instance.CurrentOrderServer = data;

                _baseViewModel.GoPage(
                    data.Type == 1 ? PageConstants.PageNameOrderBar : PageConstants.PageNameOrderTable);
            }

            public void OnCreate() { }
        }
    }
}
