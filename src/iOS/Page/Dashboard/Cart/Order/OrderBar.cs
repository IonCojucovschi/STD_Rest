// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Core.Models.DAL;
using Core.ViewModels.Beer;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Factories.Adapter;
using iOS.Page.BasePage;
using UIKit;
using static Core.ViewModels.Beer.Order.BaseOrderViewModel;

namespace iOS.Storyboard
{
    public partial class OrderBar : BasePageNavigation<OrderBarViewModel>
    {
        public OrderBar(IntPtr handle) : base(handle)
        {
        }

        protected override void BindViews()
        {
            base.BindViews();

            var source = ComponentViewSourceFactory.CreateForTable(nameof(OrderBarCell),
                                                                   new List<IOrderContent>(),
                                                         TableView,
                                                                   crossCellModel: new OrderListBaseCell(ModelView));
            TableView.Source = source;
        }
    }

    partial class OrderBar
    {
        [CrossView(nameof(OrderBarViewModel.OrderCode))]
        UILabel view1 => lblOrderCode;

        [CrossView(nameof(OrderBarViewModel.OrderCodeValue))]
        UILabel view2 => lblOrderCodeValue;

        [CrossView(nameof(OrderBarViewModel.OrderBackround))]
        UIView view3 => viewNrBar;


        [CrossView(nameof(OrderBarViewModel.ListView))]
        UITableView view4 => TableView;

        [CrossView(nameof(OrderBarViewModel.BackroundContent))]
        UIView view5 => viewContent;
    }
}
