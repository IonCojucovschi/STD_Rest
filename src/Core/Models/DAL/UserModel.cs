//
//  UserModel.cs
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
using Int.Core.Application.Contract;
using Int.Core.Data.Repository.Akavache.Contract;
using System.Collections.Generic;

namespace Core.Models.DAL
{
    public class UserModel : IUser, IBaseEntity
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool Remember { get; set; }

        public IList<OrderContent> Orders { get; set; } = new List<OrderContent>();


        public int AllCountOrders => Orders?.Count ?? 0;
    }
}
