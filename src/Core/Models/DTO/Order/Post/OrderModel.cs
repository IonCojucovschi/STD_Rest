//
//  OrderModel.cs
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

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Models.DTO.Order
{
    public class OrderUpdateModel : Notification.Post.NotificationModel
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }

    public class OrderModel : CallModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("type")]
        public OrderType Type { get; set; }

        [JsonProperty("products")]
        public IList<Product> Products { get; set; }
    }

    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }
    }

    public class CallModel
    {
        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }

        [JsonProperty("number_table")]
        public string NumberTable { get; set; }

    }
}
