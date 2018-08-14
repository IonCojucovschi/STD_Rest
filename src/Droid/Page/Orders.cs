using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.DTO.Order.Get;
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
    public partial class Orders : NavigationBasePage<OrdersViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.orders_list_layout;

        protected override void InitViews()
        {
            base.InitViews();

            ListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                             new OrdersItemCellViewHolder(inflater,
                                               parent,
                                               ModelView.CellModel)));
        }
    }

    public class OrdersItemCellViewHolder : ComponentViewHolder<OrderModel>
    {
        public OrdersItemCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                       ICrossCellViewHolder<OrderModel> cellModel)
            : base(inflator.Inflate(Resource.Layout.order_item_list, parent, false), cellModel) { }

        [CrossView(nameof(OrdersViewModel.OrdersListCell.ItemTypeOrder))]
        [InjectView(Resource.Id.type_of_order)]
        public TextView ItemTypeOrder { get; set; }

        [CrossView(nameof(OrdersViewModel.OrdersListCell.DateTimeText))]
        [InjectView(Resource.Id.order_time_item)]
        public TextView DateTimeText { get; set; }

        [CrossView(nameof(OrdersViewModel.OrdersListCell.PriceText))]
        [InjectView(Resource.Id.order_price_item)]
        public TextView PriceText { get; set; }

        [CrossView(nameof(OrdersViewModel.OrdersListCell.OrderIdText))]
        [InjectView(Resource.Id.order_number_id)]
        public TextView OrderIdText { get; set; }


        [CrossView(nameof(OrdersViewModel.OrdersListCell.CellContentRootView))]
        [InjectView(Resource.Id.order_cell_root_view)]
        public View CellContentRootView { get; set; }
    }
}