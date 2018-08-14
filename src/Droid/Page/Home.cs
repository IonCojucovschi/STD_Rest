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


using Android.App;
using Android.Content.PM;
using Android.Views;
using Core.ViewModels;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Android.Widget;
using Int.Droid.Wrappers;
using Int.Core.Application.Menu.Contract;

namespace Droid.Page
{
    [Activity(Theme = "@style/AppTheme",
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class Home : BasePage<HomeViewModel>
    {
        protected override int LayoutResource => Resource.Layout.home;

        protected override void InitViews()
        {
            base.InitViews();

            ListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                              new HomeItemCellViewHolder(inflater,
                                               parent,
                                               ModelView.CellModel)));
        }

        public override void OnBackPressed()
        {
            CloseApp();
        }
    }

    public class HomeItemCellViewHolder : ComponentViewHolder<IItemMenu>
    {
        public HomeItemCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                      ICrossCellViewHolder<IItemMenu> cellModel)
            : base(inflator.Inflate(Resource.Layout.home_list_item, parent, false), cellModel) { }

        [CrossView(nameof(HomeViewModel.HomeListCell.NameImage))]
        [InjectView(Resource.Id.item_list_image)]
        public ImageView ItemImage { get; set; }

        [CrossView(nameof(HomeViewModel.HomeListCell.NameText))]
        [InjectView(Resource.Id.item_list_text)]
        public TextView ItemNameText { get; set; }

        [CrossView(nameof(HomeViewModel.HomeListCell.CellContentRootView))]
        [InjectView(Resource.Id.wrapp_item_content)]
        public RelativeLayout CellContent { get; set; }

        //[CrossView(nameof(HomeViewModel.HomeListCell.))]
        [InjectView(Resource.Id.view_item_home)]
        public View View1 { get; set; }
    }
}
