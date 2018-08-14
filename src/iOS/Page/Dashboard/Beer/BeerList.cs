// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Core.Models.DAL;
using Core.ViewModels.Beer;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Factories.Adapter;
using iOS.Page.BasePage;
using UIKit;

namespace iOS.Storyboard
{
    public partial class BeerList : BasePageNavigation<BeerListViewModel>
    {
        public BeerList(IntPtr handle) : base(handle) { }

        protected override void BindViews()
        {
            base.BindViews();

            var source = ComponentViewSourceFactory.CreateForTable(nameof(BeerListCell),
                                                                   new List<List<IBeerContent>>(),
                                                                   TableView,
                                                                   crossCellModel: new BeerListViewModel.BeerListCell(ModelView));
            TableView.Source = source;
        }
    }

    public partial class BeerList
    {
        [CrossView(nameof(BeerListViewModel.ListView))]
        UITableView propName1 => TableView;

        [CrossView(nameof(BeerListViewModel.BackroundContent))]
        UIView propName2 => viewContent;
    }
}
