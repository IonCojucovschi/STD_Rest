//
//  MenuManager.cs
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
using System.Linq;
using Core.Models.DAL.Home;
using Core.Resources.Drawables;
using Int.Core.Application.Menu.Contract;
using Int.Core.Network.Singleton;

namespace Core.Helpers.Manager.Home
{
    public class MenuManager : Singleton<MenuManager>
    {
        private static IList<IItemMenu> Items => new List<IItemMenu> {

            //new HomeItem { ClickArgument = PageConstants.PageNameCreateAccount, PageActive = true, ImageMenu = DrawableConstants.HomeIcon, ImageHome = DrawableConstants.BeerHomeIcon, Name = "Sign", Page = TypePage.Sign},
            //new HomeItem { ClickArgument = PageConstants.PageNameSign, PageActive = true, ImageMenu = DrawableConstants.FoodIcon, ImageHome = DrawableConstants.FoodHomeIcon, Name = "Create an Account", Page = TypePage.Register },

                new HomeItem { ClickArgument = PageConstants.PageNameBeerList, PageActive = true, ImageMenu = DrawableConstants.BeerIcon, ImageHome = DrawableConstants.BeerHomeIcon, Name = "Beer", Page = TypePage.Beer},
                new HomeItem { ClickArgument = PageConstants.PageNameOrders, PageActive = OrderManager.Instance.OrderMenu  , ImageMenu = DrawableConstants.OrderIcon, ImageHome = DrawableConstants.OrderHomeIcon, Name = "Orders", Page = TypePage.Orders },
                new HomeItem { ClickArgument = PageConstants.PageNameCall, PageActive = true, ImageMenu = DrawableConstants.CallIcon, ImageHome = DrawableConstants.CallHomeIcon, Name = "Call Waiter", Page = TypePage.Call },
                new HomeItem { ClickArgument = PageConstants.PageNameEvents,  PageActive = true,ImageMenu = DrawableConstants.EventsIcon, ImageHome = DrawableConstants.EventsHomeIcon, Name = "Events", Page = TypePage.Events },
                new HomeItem { ClickArgument = PageConstants.PageNameFeedback, PageActive = true, ImageMenu = DrawableConstants.FeedbackIcon, ImageHome = DrawableConstants.FeedbackHomeIcon, Name = "Feedback", Page = TypePage.Feedback }
        };

        public IList<IItemMenu> GetItem()
        {
            return Items.OfType<IHome>().Where(x => x.Page != TypePage.Home).ToList<IItemMenu>();
        }

        public IList<IItemMenu> GetMenuItem()
        {
            return Items;
        }
    }
}
