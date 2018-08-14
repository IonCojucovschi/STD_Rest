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
using Core.Models.DAL;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Core.ViewModels.Beer.Order;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Beer
{
    public class OrderViewModel : BaseOrderPaymentViewModel
    {
        protected override string HeaderText => ROrderView.Cart;

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Back;

        [CrossView]
        public IText OrderTableText { get; private set; }

        [CrossView]
        public IText OrderBarText { get; private set; }


        public override void UpdateData()
        {
            base.UpdateData();

            CellModel = new OrderListCell(this);

            if (OrderTableText != null)
            {
                OrderTableText.Click -= OrderTableText_Click;
                OrderTableText.Click += OrderTableText_Click;

                OrderTableText.Text = $"{ROrderView.OrderAtTable} (€{OrderManager.Instance.GetItem().Sum(x => x.Price * Convert.ToInt32(x.Quantity))})".ToUpperInvariant();

                OrderTableText.SetTextColor(ColorConstants.WhiteColor);
                OrderTableText.SetBackgroundColor(ColorConstants.BlackColor);
                OrderTableText.SetSelectedColor(ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent50));
                OrderTableText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
            }

            if (OrderBarText == null) return;

            OrderBarText.Click -= OrderBarText_Click;
            OrderBarText.Click += OrderBarText_Click;
            OrderBarText.SetTextColor(ColorConstants.WhiteColor);
            OrderBarText.Text = $"{ROrderView.OrderAtBar} (€{OrderManager.Instance.GetItem().Sum(x => x.PriceBar * Convert.ToInt32(x.Quantity))})".ToUpperInvariant();

            OrderBarText.SetBackgroundColor(ColorConstants.SelectorHome);
            OrderBarText.SetSelectedColor(ColorConstants.SelectorHome.SelectorTransparence(ColorConstants.Procent50));
            OrderBarText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
        }

        private void OrderTableText_Click(object sender, EventArgs e)
        {
            if (OrderManager.Instance.GetItem().Sum(x => x.Price * Convert.ToInt32(x.Quantity)) > 0)
                this.GoPage(PageConstants.PageNameCode);
        }

        private void OrderBarText_Click(object sender, EventArgs e)
        {
            if (!(OrderManager.Instance.GetItem().Sum(x => x.PriceBar * Convert.ToInt32(x.Quantity)) > 0)) return;

            Show();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                OrderManager.Instance.AddOrder(Models.DTO.OrderType.Bar, (obj) =>
                {
                    if (App.Instance.GetView(typeof(OrderBarViewModel)) is OrderBarViewModel a) a.TableNumber = obj.ToString();

                    TableNumber = obj.ToString();
                    GetPayment?.Invoke(Verify);
                    Hide();
                }, (obj) =>
                {
                    ShowError(obj.Replace(",", Environment.NewLine).Trim());
                });
            });
        }

        public class OrderListCell : ICrossCellViewHolder<IOrderContent>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public BaseOrderPaymentViewModel CurrentViewModel => _baseViewModel as BaseOrderPaymentViewModel;

            public OrderListCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IImage CategoryImage { get; set; }

            [CrossView]
            public IImage RemoveOrderImage { get; set; }

            [CrossView]
            public IText ItemNameText { get; set; }

            [CrossView]
            public IText QuantityText { get; set; }

            [CrossView]
            public IText PriceText { get; set; }


            [CrossView]
            public IText MinusText { get; set; }

            [CrossView]
            public IText PlusText { get; set; }

            public void Bind(IOrderContent model)
            {
                CellContentRootView?.SetBackgroundColor(ColorConstants.BackroundCell, 5);
                CategoryImage?.SetImageFromUrl(model.ImagePath);

                if (!RemoveOrderImage.IsNull())
                {
                    RemoveOrderImage?.SetImageFromResource(DrawableConstants.OrderRemoveIcon);

                    RemoveOrderImage.Tag = model;

                    RemoveOrderImage.Click -= RemoveOrderImage_Click;
                    RemoveOrderImage.Click += RemoveOrderImage_Click;
                }

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

                if (!MinusText.IsNull())
                {
                    MinusText?.SetTextColor(ColorConstants.WhiteColor);
                    MinusText?.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size20);
                    MinusText?.SetBackgroundColor(ColorConstants.SelectorHome, type: RadiusType.Aspect);
                    MinusText?.SetSelectedColor(ColorConstants.SelectorHome.SelectorTransparence(ColorConstants.Procent50));
                    MinusText.Text = "-";
                    MinusText.Tag = new { Model = model };

                    MinusText.Click -= MinusText_Click;
                    MinusText.Click += MinusText_Click;
                }

                if (!QuantityText.IsNull())
                {
                    QuantityText.Text = model.Quantity;
                    QuantityText?.SetTextColor(ColorConstants.WhiteColor);
                    QuantityText?.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                }

                if (PlusText.IsNull()) return;
                PlusText?.SetTextColor(ColorConstants.WhiteColor);
                PlusText?.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size20);
                PlusText.Text = "+";
                PlusText?.SetBackgroundColor(ColorConstants.SelectorHome, type: RadiusType.Aspect);
                PlusText?.SetSelectedColor(ColorConstants.SelectorHome.SelectorTransparence(ColorConstants.Procent50));

                PlusText.Tag = new { Model = model };

                PlusText.Click -= PlusText_Click;
                PlusText.Click += PlusText_Click;
            }

            private void RemoveOrderImage_Click(object sender, EventArgs e)
            {
                var view = (sender as IView)?.Tag;

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    if (!(view is OrderContent model)) return;
                    OrderManager.Instance.RemoveOrder(model.IdProduct);
                    CurrentViewModel?.UpdateData();
                });
            }

            private void MinusText_Click(object sender, EventArgs e)
            {
                CurrentViewModel.MinusView(sender as IView);
            }

            private void PlusText_Click(object sender, EventArgs e)
            {
                CurrentViewModel.PlusView(sender as IView);
            }

            public void OnCreate() { }
        }
    }
}
