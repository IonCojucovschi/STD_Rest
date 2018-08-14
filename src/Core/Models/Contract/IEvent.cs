//
//  IEvent.cs
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
using Int.Core.Extensions;

namespace Core.Models.Contract
{
    public enum EventType
    {
        Day,
        Month
    }

    public interface IEvent : IMoveModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string ImagePathView { get; set; }

        string ImageOriginal { get; set; }

        DateTime EventDateTime { get; set; }

        bool SelectedTag { get; set; }

        string ColorTag { get; set; }

        EventType IsDay { get; set; }

        IList<Core.Models.DTO.Image> Images { get; set; }
    }
}
