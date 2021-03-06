// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Core.Models.Contract;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Factories.Adapter;
using iOS.Page.BasePage;
using UIKit;

namespace iOS.Storyboard
{
    public partial class Events : BasePageNavigation<EventsViewModel>
    {
        public Events(IntPtr handle) : base(handle) { }

        protected override void BindViews()
        {
            base.BindViews();

            CollectionView.Source = ComponentViewSourceFactory.CreateForCollection(nameof(EventCollectionCell),
                                                                                   new List<IEvent>(),
                                                                                   CollectionView,
                                                                                   crossCellModel: new EventsViewModel.EventsListTagCell(ModelView));

            var daa = CollectionView.CollectionViewLayout as UICollectionViewFlowLayout;

            daa.ScrollDirection = UICollectionViewScrollDirection.Horizontal;
            daa.EstimatedItemSize = new CoreGraphics.CGSize(1, 33);

            CollectionViewSubTag.Source = ComponentViewSourceFactory.CreateForCollection(nameof(EventCollectionSubTagCell),
                                                                                         new List<IEvent>(),
                                                                                     CollectionViewSubTag,
                                                                                     crossCellModel: new EventsViewModel.EventsListSubTagCell(ModelView));

            TableView.Source = ComponentViewSourceFactory.CreateForTable(nameof(EventNameCell),
                                                                         new List<IEvent>(),
                                                                         TableView,
                                                                         crossCellModel: new EventsViewModel.EventNameListCell(ModelView));
        }
    }

    partial class Events
    {
        [CrossView(nameof(EventsViewModel.ListView))]
        UICollectionView view1 => CollectionView;

        [CrossView(nameof(EventsViewModel.ListSubTagView))]
        UICollectionView view2 => CollectionViewSubTag;

        [CrossView(nameof(EventsViewModel.ListEventNameView))]
        UITableView view3 => TableView;

        [CrossView(nameof(EventsViewModel.MonthText))]
        UILabel view4 => lblMonth;

        [CrossView(nameof(EventsViewModel.LeftArrow))]
        UIImageView view5 => imgLeft;

        [CrossView(nameof(EventsViewModel.RightArrow))]
        UIImageView view7 => imgRight;

        [CrossView(nameof(EventsViewModel.IntervalEventsDate))]
        UILabel view8 => lblMonthOrDay;

        [CrossView(nameof(EventsViewModel.BackroundContent))]
        UIView view6 => viewContentBackround;
    }
}
