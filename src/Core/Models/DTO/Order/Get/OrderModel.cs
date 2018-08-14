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
using Core.Models.DAL;
using Newtonsoft.Json;
using System.Linq;

namespace Core.Models.DTO.Order.Get
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("total_amount")]
        public int TotalAmount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("products")]
        public IList<Product> Products { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }
    }

    public class Product : IOrderContent
    {
        [JsonProperty("name")]
        public string OrderName { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("total_price")]
        public double PriceBar { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }


        [JsonProperty("images")]
        public IList<Image> Images { get; set; }


        public int Id { get; set; }
        public int IdProduct { get; set; }

        public string ImagePath
        {
            get => Images?.FirstOrDefault()?.Path;
            set => Images.FirstOrDefault().Path = value;
        }

    }
}
