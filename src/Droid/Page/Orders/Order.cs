//
// Splash.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2017 Songurov Fiodor
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.DAL;
using Core.ViewModels.Beer;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    [Activity(Theme = "@style/AppTheme",
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class Order : NavigationBasePage<OrderViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.cart_list;

        private Action<string> _result { get; set; }

        protected override void InitViews()
        {
            base.InitViews();

            ListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                             new OrderItemCellViewHolder(inflater,
                                               parent,
                                               ModelView.CellModel)));
            ModelView.GetPayment -= ModelView_GetPayment;
            ModelView.GetPayment += ModelView_GetPayment;
        }

        private void ModelView_GetPayment(Action<string> arg)
        {
            Helpers.PPHelper.Buy();
            _result = arg;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            Helpers.PPHelper.ProcessResponse(requestCode, resultCode, data, (objPayId) =>
            {
                _result?.Invoke(objPayId);
            }, () =>
            {
                ShowError("Error Payment");
            }, () =>
            {
                //ShowError("Cancel Payment");
            });
        }
    }

    public class OrderItemCellViewHolder : ComponentViewHolder<IOrderContent>
    {
        public OrderItemCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                       ICrossCellViewHolder<IOrderContent> cellModel)
            : base(inflator.Inflate(Resource.Layout.cart_item_list, parent, false), cellModel) { }

        [CrossView(nameof(OrderViewModel.OrderListCell.CategoryImage))]
        [InjectView(Resource.Id.item_image)]
        public ImageView ItemImage { get; set; }

        [CrossView(nameof(OrderViewModel.OrderListCell.RemoveOrderImage))]
        [InjectView(Resource.Id.item_garbadge_img)]
        public ImageView RemoveOrderImage { get; set; }


        [CrossView(nameof(OrderViewModel.OrderListCell.ItemNameText))]
        [InjectView(Resource.Id.item_name)]
        public TextView ItemNameText { get; set; }

        [CrossView(nameof(OrderViewModel.OrderListCell.QuantityText))]
        [InjectView(Resource.Id.quantity_item)]
        public TextView QuantityText { get; set; }

        [CrossView(nameof(OrderViewModel.OrderListCell.MinusText))]
        [InjectView(Resource.Id.minus_item)]
        public TextView MinusText { get; set; }

        [CrossView(nameof(OrderViewModel.OrderListCell.PlusText))]
        [InjectView(Resource.Id.plus_item)]
        public TextView PlusText { get; set; }


        [CrossView(nameof(OrderViewModel.OrderListCell.PriceText))]
        [InjectView(Resource.Id.price_item)]
        public TextView PriceText { get; set; }

        [CrossView(nameof(OrderViewModel.OrderListCell.CellContentRootView))]
        [InjectView(Resource.Id.wrapp_item_content)]
        public View CellContent { get; set; }

    }
}