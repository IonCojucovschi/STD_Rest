//
//  OrderManager.cs
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
using System.Collections.Generic;
using System.Linq;
using Core.Models.DAL;
using Core.Models.DTO;
using Core.Services.MockServices.RealServices;
using Int.Core.Network.Singleton;
using Plugin.DeviceInfo;
using Splat;

namespace Core.Helpers.Manager
{
    public enum OrderVisibility
    {
        Local,
        Server
    }

    public class OrderManager : Singleton<OrderManager>
    {
        private static UserModel CurrentUser => UserManager.Instance.CurrentUser() as UserModel;

        public OrderVisibility OrderType { get; set; }

        public IList<IOrderContent> GetItem()
        {
            var list = new List<IOrderContent>();

            if (OrderType == OrderVisibility.Local)
            {
                if (CurrentUser?.Orders != null) list.AddRange((CurrentUser?.Orders));
            }
            else
            {
                if (CurrentOrderServer?.Products != null) list.AddRange((CurrentOrderServer?.Products));
            }

            return list;
        }

        public double GetPrice => TypeOrder == Core.Models.DTO.OrderType.Bar ? GetItem().Sum(x => x.PriceBar * Convert.ToInt32(x.Quantity)) :
                                    GetItem().Sum(x => x.Price * Convert.ToInt32(x.Quantity));

        public int CurrentOrderCount => GetItem() != null ? GetItem().Count : 0;

        public bool OrderMenu => _orderServerLocal?.Count > 0;

        public Action<string> ChangeOrder { get; set; }

        public void AddOrder(OrderContent orderContents, bool isIncriment)
        {
            var orders = new List<OrderContent>();

            if (IncrimentCurrentOrder(CurrentUser?.Orders, orderContents, isIncriment))
            {
                orders.Add(orderContents);
                orders.AddRange(CurrentUser?.Orders ?? throw new InvalidOperationException());
                UserManager.Instance.UpdateUser(new UserModel { Orders = orders });
            }

            ChangeOrder?.Invoke(CurrentUser?.Orders?.FirstOrDefault(x => x.IdProduct == orderContents.IdProduct)?.Quantity ?? "0");
        }

        public void RemoveOrder(int idProduct)
        {
            var orders = new List<OrderContent>();

            orders.AddRange(CurrentUser?.Orders ?? throw new InvalidOperationException());

            orders.RemoveAll(x => x.IdProduct == idProduct);

            UserManager.Instance.UpdateUser(new UserModel { Orders = orders });
        }

        private bool IncrimentCurrentOrder(IList<OrderContent> list, IOrderContent orderContent, bool isIncriment)
        {
            var a = list?.FirstOrDefault(x => x.IdProduct == orderContent.IdProduct);

            if (a == null) return true;
            if (isIncriment)
            {
                a.Quantity = (Convert.ToInt32(a.Quantity) + Convert.ToInt32(orderContent.Quantity)).ToString();
                UserManager.Instance.UpdateUser(new UserModel { Orders = list });
            }
            else
            {
                if (a.Quantity == "1")
                    RemoveOrder(a.IdProduct);
                else
                {
                    a.Quantity = (Convert.ToInt32(a.Quantity) - Convert.ToInt32(orderContent.Quantity)).ToString();
                    UserManager.Instance.UpdateUser(new UserModel { Orders = list });
                }
            }

            return false;
        }

        public int? GetQuantityProduct(int productId) => CurrentUser?.Orders?.Where(x => x?.IdProduct == productId).Sum(x => Convert.ToInt32(x.Quantity));

        private readonly Models.DTO.Order.OrderModel _orderServer = new Models.DTO.Order.OrderModel();

        private void ParseModel(OrderType type)
        {
            TypeOrder = type;
            _orderServer.Type = type;
            _orderServer.Products = new List<Core.Models.DTO.Order.Product>();

            foreach (var item in GetItem())
                _orderServer.Products.Add(new Core.Models.DTO.Order.Product { Id = item.IdProduct.ToString(), Quantity = item.Quantity });
        }

        public Models.DTO.Order.Get.OrderModel CurrentOrderServer { get; set; }

        private IList<Models.DTO.Order.Get.OrderModel> _orderServerLocal;
        public void GetOrder(Action<IList<Models.DTO.Order.Get.OrderModel>> orderContents, Action<string> error)
        {
            GetOrderServer(CrossDeviceInfo.Current.Id,
                contactInfo =>
                {
                    _orderServerLocal = contactInfo;
                    orderContents?.Invoke(contactInfo);
                }, error);
        }

        public void ClearOrder()
        {
            if (OrderType == OrderVisibility.Local)
                UserManager.Instance.UpdateUser(new UserModel { Orders = new List<OrderContent>() });
        }

        private OrderType TypeOrder { get; set; }

        public void AddOrder(OrderType type, Action<int> success, Action<string> error, string code = "")
        {
            TypeOrder = type;

            int.TryParse(code, out var result);
            _orderServer.Code = result;
            _orderServer.DeviceToken = CrossDeviceInfo.Current.Id;

            ParseModel(type);

            AddOrderServer(_orderServer,
                           (obj) =>
            {
                success?.Invoke(obj);
            }, (obj) =>
            {
                error?.Invoke(obj);
            });
        }

        public void UpdateOrder(string tableNr, Action success, Action<string> error)
        {
            TypeOrder = Models.DTO.OrderType.Table;

            var model = new Models.DTO.Order.OrderUpdateModel
            {
                CodeTable = tableNr,
                OrderId = CurrentOrderServer.Id.ToString()
            };

            UpdateOrderServer(CrossDeviceInfo.Current.Id, model,
                           () =>
                           {
                               CurrentOrderServer.Code = tableNr;
                               success?.Invoke();
                           }, (obj) =>
                           {
                               error?.Invoke(obj);
                           });
        }

        #region serivce

        private void AddOrderServer(Models.DTO.Order.OrderModel model, Action<int> success, Action<string> error)
        {
            GetService.AddOrder(model, success, error);
        }

        private void UpdateOrderServer(string deviceToken, Models.DTO.Order.OrderUpdateModel model, Action success, Action<string> error)
        {
            GetService.UpdateOrder(deviceToken, model, success, error);
        }

        private void GetOrderServer(string deviceToken, Action<IList<Models.DTO.Order.Get.OrderModel>> success, Action<string> error)
        {
            GetService.GetOrder(deviceToken, success, error);
        }

        public void AddNotification(string tableNr, Action success, Action<string> error)
        {
            GetServiceNotification.Notification(new Models.DTO.Notification.Post.NotificationModel
            {
                DeviceToken = CrossDeviceInfo.Current.Id,
                CodeTable = tableNr
            }, success, error);
        }


        private static IOrder GetService =>
            Locator.Current.GetService<IOrder>(App.Instance.IsMock
                                ? App.ServiceContractMock
                                : App.ServiceContract);

        private static INotification GetServiceNotification =>
            Locator.Current.GetService<INotification>(App.Instance.IsMock
                               ? App.ServiceContractMock
                               : App.ServiceContract);

        #endregion
    }
}
