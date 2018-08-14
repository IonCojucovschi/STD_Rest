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
using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Core.Models.DAL;
using Core.ViewModels.Beer;
using Droid.Page.Base;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;
using Android.Widget;
using Android.Views;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid;
using FFImageLoading.Views;
using Android.Content;

namespace Droid.Page
{
    [Activity(Theme = "@style/AppTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              LaunchMode = LaunchMode.SingleTop,
              ScreenOrientation = ScreenOrientation.Portrait, HardwareAccelerated = true)]
    public partial class BeerList : NavigationBasePage<BeerListViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.beer_list;

        protected override void InitViews()
        {
            base.InitViews();

            ListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                            new BeerItemCellViewHolder(inflater,
                                              parent,
                                              ModelView.CellModel)));
        }

        public override void OnTrimMemory(TrimMemory level)
        {
            FFImageLoading.ImageService.Instance.InvalidateMemoryCache();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            base.OnTrimMemory(level);
        }
        public override void OnLowMemory()
        {
            FFImageLoading.ImageService.Instance.InvalidateMemoryCache();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            base.OnLowMemory();
        }
    }

    public class BeerItemCellViewHolder : ComponentViewHolder<List<IBeerContent>>
    {
        public BeerItemCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                      ICrossCellViewHolder<List<IBeerContent>> cellModel)
            : base(inflator.Inflate(Resource.Layout.ber_list_item, parent, false), cellModel) { }

        ///left Side
        [CrossView(nameof(BeerListViewModel.BeerListCell.MainViewLeft))]
        [InjectView(Resource.Id.left_side_item)]
        public LinearLayout MainViewLeft { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Image))]
        [InjectView(Resource.Id.beer_item_image_left)]
        public ImageViewAsync Beer1Image { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Image2))]
        [InjectView(Resource.Id.beer_item_image2_left)]
        public ImageViewAsync Beer1Image2 { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1WrapperContent))]
        [InjectView(Resource.Id.beer_vrapper_content_left)]
        public LinearLayout Beer1WrapperContent { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Name))]
        [InjectView(Resource.Id.beer_name_text_left)]
        public TextView Beer1Name { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Price))]
        [InjectView(Resource.Id.beer_price_text_left)]
        public TextView Beer1Price { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Volume))]
        [InjectView(Resource.Id.beer_volume_text_left)]
        public TextView Beer1Volume { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Add))]
        [InjectView(Resource.Id.add_item_service_left)]
        public TextView Beer1Add { get; set; }

        ///right Side
        [CrossView(nameof(BeerListViewModel.BeerListCell.MainViewRight))]
        [InjectView(Resource.Id.right_side_item)]
        public LinearLayout MainViewRight { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Image))]
        [InjectView(Resource.Id.beer_item_image_right)]
        public ImageViewAsync Beer2Image { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Image2))]
        [InjectView(Resource.Id.beer_item_image2_right)]
        public ImageViewAsync Beer2Image2 { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2WrapperContent))]
        [InjectView(Resource.Id.beer_vrapper_content_right)]
        public LinearLayout Beer2WrapperContent { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Name))]
        [InjectView(Resource.Id.beer_name_text_right)]
        public TextView Beer2Name { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Price))]
        [InjectView(Resource.Id.beer_price_text_right)]
        public TextView Beer2Price { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Volume))]
        [InjectView(Resource.Id.beer_volume_text_right)]
        public TextView Beer2Volume { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Add))]
        [InjectView(Resource.Id.add_item_service_right)]
        public TextView Beer2Add { get; set; }


        ///left side add items
        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1AddContent))]
        [InjectView(Resource.Id.wraper_view_quantity_left)]
        public LinearLayout Beer1AddContent { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Minus))]
        [InjectView(Resource.Id.minus_item_left)]
        public TextView Beer1Minus { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Counter))]
        [InjectView(Resource.Id.quantity_item_left)]
        public TextView Beer1Counter { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Plus))]
        [InjectView(Resource.Id.plus_item_left)]
        public TextView Beer1Plus { get; set; }

        ///right side add items
        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2AddContent))]
        [InjectView(Resource.Id.wraper_view_quantity_right)]
        public LinearLayout Beer2AddContent { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Minus))]
        [InjectView(Resource.Id.minus_item_right)]
        public TextView Beer2Minus { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Counter))]
        [InjectView(Resource.Id.quantity_item_right)]
        public TextView Beer2Counter { get; set; }

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Plus))]
        [InjectView(Resource.Id.plus_item_right)]
        public TextView Beer2Plus { get; set; }
    }
}
