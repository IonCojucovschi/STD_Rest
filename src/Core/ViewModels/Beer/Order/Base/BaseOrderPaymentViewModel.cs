//
//  BaseOrderPaymentViewModel.cs
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
using Core.Helpers.Manager.Payment;
using Core.Models.DAL;
using Int.Core.Application.Widget.Contract;

namespace Core.ViewModels.Beer.Order
{
    public abstract class BaseOrderPaymentViewModel : BaseOrderViewModel
    {
        public Action<Action<string>> GetPayment { get; set; }

        protected void Verify(string id)
        {
            Show();
            ThreadPool.QueueUserWorkItem(_ =>
            {
                PaymentManager.Instance.VerifyPayment(new Models.DTO.Payment.PaymentModel
                {
                    PaymentId = id,
                    OrderId = TableNumber
                }, () =>
                {
                    OrderManager.Instance.ClearOrder();
                    this.GoPage(PageConstants.PageNameHome);
                }, (obj) => ShowError(obj));
            });
        }

        public void PlusView(IView view)
        {
            dynamic data = view?.Tag;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                if (ProductManager.Instance.GetItem().FirstOrDefault(x => x.Id == data?.Model.IdProduct).Quantity >
                    Convert.ToInt32(OrderManager.Instance.GetItem().FirstOrDefault(x => x.IdProduct == data?.Model.IdProduct)?.Quantity))
                    AddOrder(data?.Model as OrderContent, true);
            });
        }

        public void MinusView(IView view)
        {
            dynamic data = view?.Tag;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                AddOrder(data?.Model as OrderContent, false);

                if (data?.Model is OrderContent model1)
                    if (!(OrderManager.Instance.GetQuantityProduct(model1.IdProduct) <= 0)) return;

                if (!(data?.Model is OrderContent model)) return;
                OrderManager.Instance.RemoveOrder(model.IdProduct);
                this.UpdateData();
            });
        }

        private void AddOrder(OrderContent model, bool isIncriment)
        {
            model.Quantity = "1";

            OrderManager.Instance.AddOrder(model, isIncriment);

            this.UpdateData();
        }
    }
}
