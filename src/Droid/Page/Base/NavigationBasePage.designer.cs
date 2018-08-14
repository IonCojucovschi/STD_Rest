//
//  NavigationBasePage.designer.cs
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
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Core.ViewModels.Base;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page.Base
{
    partial class NavigationBasePage<TViewModel>
    {
        [InjectView(Resource.Id.side_menu_root_view)]
        public FrameLayout SideMenuRootView { get; set; }


        [InjectView(Resource.Id.drawer_layout)]
        public DrawerLayout Drawer { get; set; }


        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderLeftTouchArea))]
        [InjectView(Resource.Id.left_button_container)]
        public LinearLayout HeaderLeftTouchAreaView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.BottomHeaderLine))]
        [InjectView(Resource.Id.bottom_line_header)]
        public View BottomHeaderLine { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderLeftImageView))]
        [InjectView(Resource.Id.left_button_image)]
        public ImageView HeaderLeftImageView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRootView))]
        [InjectView(Resource.Id.header_root_view)]
        public View HeaderRootView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRightTouchArea))]
        [InjectView(Resource.Id.right_button_container)]
        public LinearLayout HeaderRightTouchAreaView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRightImageView))]
        [InjectView(Resource.Id.right_button_image)]
        public ImageView HeaderRightImageView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderTextView))]
        [InjectView(Resource.Id.header_text_view)]
        public TextView HeaderTextView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.CounterTextView))]
        [InjectView(Resource.Id.order_number)]
        public TextView CounterTextView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuListView))]
        [InjectView(Resource.Id.side_menu_list)]
        public BaseRecyclerView SideMenuListView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideImage))]
        [InjectView(Resource.Id.menu_image_icon)]
        public ImageView MenuIcon { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.MenuLine))]
        [InjectView(Resource.Id.menu_line_item)]
        public View MenuLine { get; set; }

    }
}
