//
//  MenuView.cs
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
using Int.iOS.Views;
using UIKit;

namespace iOS.Views.Window.Menu.UI
{
    public class MenuView : UIViewXib
    {
        private readonly SideMenuView _view;

        public MenuView() : base(nameof(SideMenuView)) => _view = CreateObject<SideMenuView>();

        public UIView RootView => _view.RootView;

        public UITableView TableView => _view.TTableView;

        public UIImageView ImageMenu => _view.ImageViewMenu;
        public UIView TouchAreMenu => _view.TouchAreMenu;

        public UIView Container => _view.ViewContainer;

    }
}
