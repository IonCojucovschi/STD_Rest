//
//  Extensions.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2017 Songurov
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

using Int.Core.Data.MVVM.Contract;
using RestSharp;
using Int.Core.Extensions;
using System;
using Int.Core.Application.Window.Contract;
using Int.Core.Application.Widget.Contract;
using System.Timers;

namespace Core.Extensions
{
    public static class Extensions
    {
        public static IRestRequest AddToken(this IRestRequest request, string token)
        {
            request.AddHeader("Authorization", $"Bearer {token}");
            return request;
        }

        public static void GoPage(this IBaseViewModel @this, string page)
        {
            if (page.IsNullOrWhiteSpace()) return;
            var pageRoot = App.Instance.NameSpacePage() + "." + page;
            @this.GoPage(Type.GetType(pageRoot));
        }

        public static string SelectorTransparence(this string @this, string transparence)
        {
            return @this.Replace("#", "#" + transparence);
        }

        public static void GetWindow<TWindow, TViewModel>(this IBaseViewModel @this)
         where TWindow : IPopupWindow, new() where TViewModel : IBaseViewModel
        {
            @this.GetWindow<TWindow>(App.Instance.GetView(typeof(TViewModel)));
        }
    }
}
