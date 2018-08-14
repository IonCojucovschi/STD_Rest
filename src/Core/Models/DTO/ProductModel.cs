//
//  ProductModel.cs
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
using Newtonsoft.Json;
using Core.Models.DAL;
using System.Linq;

namespace Core.Models.DTO
{
    public class Product : IBeerContent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string NameBeer { get; set; }

        [JsonProperty("price_table")]
        public double Price { get; set; }

        [JsonProperty("price_bar")]
        public double PriceBar { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("volum")]
        public string Volume { get; set; }

        [JsonProperty("images")]
        public IList<Image> Images { get; set; }

        public string ImagePath { get => Images?.FirstOrDefault()?.Path; set => Images.FirstOrDefault().Path = value; }

        public int CountOrder { get; set; }
    }

    public class Image
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
