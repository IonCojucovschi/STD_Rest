//
//  MenuViewCell.cs
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
using Core.ViewModels.Base;
using Int.Core.Application.Menu.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Factories.Adapter.CellView;
using UIKit;

namespace iOS.Views.Window.Menu.Cell
{
    public partial class MenuViewCell : ComponentTableViewCell<IItemMenu>
    {
        protected MenuViewCell(IntPtr handle) : base(handle) { }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuCell.RootView))]
        UIView view1 => viewRoot;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuCell.Line))]
        UIView view2 => viewLine;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuCell.ImageItemMenu))]
        UIImageView view3 => imgMenu;
    }
}
