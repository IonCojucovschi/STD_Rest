//
//  Splash.designer.cs
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

using Android.Widget;
using Core.ViewModels;
using Core.ViewModels.Beer;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class Order
    {
        
        //[CrossView(nameof(OrderViewModel.MainContent))]
        //[InjectView(Resource.Id.main_content_chart)]
        //public LinearLayout  MainContent{ get; set; }

        [CrossView(nameof(OrderViewModel.ListView))]
        [InjectView(Resource.Id.cart_list_view)]
        public BaseRecyclerView ListView { get; set; }
  
        [CrossView(nameof(OrderViewModel.OrderTableText))]
        [InjectView(Resource.Id.order_at_table)]
        protected TextView OrderTableText { get; set; }

        [CrossView(nameof(OrderViewModel.OrderBarText))]
        [InjectView(Resource.Id.order_at_bar)]
        protected TextView OrderBarText { get; set; }



    }
}
