//
//  FeedbackModel.cs
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

using Newtonsoft.Json;

namespace Core.Models.DTO.Feedback.Get
{
    public class FeedbackModel
    {
        [JsonProperty("service")]
        public int Service { get; set; }

        [JsonProperty("event")]
        public int Event { get; set; }

        [JsonProperty("beer")]
        public int Beer { get; set; }
    }

    public class FeedbackServerModel : FeedbackModel
    {
        [JsonProperty("device_id")]
        public string DeviceToken { get; set; }
    }
}
