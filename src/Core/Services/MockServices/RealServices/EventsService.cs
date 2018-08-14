//
//  PaymentService.cs
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
using Core.Services.Response;
using Int.Core.Network.Response;

namespace Core.Services.MockServices.RealServices
{
    public class EventsService : IEvents
    {
        public void GetEvent(long start, long end, Action<System.Collections.Generic.List<Core.Models.DTO.Event.EventModel>> success, Action<string> error)
        {
            var response =
                RequestFactory.ExecuteRequest<MResponse<System.Collections.Generic.List<Core.Models.DTO.Event.EventModel>>>(RestCalls.Instance.GetEvent(start, end));

            response.OnResponse(() =>
            {
                success?.Invoke(response.Data);
            },
            exception => error?.Invoke(exception.Message));
        }
    }

    public interface IEvents
    {
        void GetEvent(long start, long end, Action<System.Collections.Generic.List<Core.Models.DTO.Event.EventModel>> success, Action<string> error);
    }
}
