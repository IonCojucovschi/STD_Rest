//
//  IHome.cs
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
using Int.Core.Application.Menu.Contract;
namespace Core.Models.DAL.Home
{
    public enum TypePage
    {
        Home,
        Beer,
        Food,
        Orders,
        Call,
        Events,
        Feedback,
        Sign,
        Register
    }
    public interface IHome : IItemMenu
    {
        string ImageMenu { get; set; }
        string ImageHome { get; set; }
        bool PageActive { get; set; }

        TypePage Page { get; set; }
    }

    public class HomeItem : IHome
    {
        public string ImageMenu { get; set; }
        public string ImageHome { get; set; }
        public string Name { get; set; }
        public bool PageActive { get; set; }
        public TypePage Page { get; set; }



        public string ClickArgument { get; set; }
    }
}
