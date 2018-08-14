//
//  ProductManager.cs
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
using Core.Models.DAL;
using Core.Services.MockServices.RealServices;
using Int.Core.Extensions;
using Int.Core.Network.Singleton;
using Splat;

namespace Core.Helpers.Manager
{
    public class ProductManager : Singleton<ProductManager>
    {
        private IList<IBeerContent> _beerContentss;
        public IEnumerable<IBeerContent> GetItem() => _beerContentss;

        public void GetProduct(Action<IList<List<IBeerContent>>> beerContents, Action<string> error)
        {
            GetCategory(
                contactInfo =>
                {
                    _beerContentss = contactInfo;

                    var a = contactInfo?.Split(2);

                    beerContents?.Invoke(a ?? new List<List<IBeerContent>>());
                }, error);
        }

        #region serivce

        private static void GetCategory(Action<IList<IBeerContent>> success, Action<string> error)
        {
            GetService.GetCategory(success, error);
        }

        private static ICategory GetService =>
                    Locator.Current.GetService<ICategory>(App.Instance.IsMock
                                ? App.ServiceContractMock
                                : App.ServiceContract);

        #endregion
    }
}
