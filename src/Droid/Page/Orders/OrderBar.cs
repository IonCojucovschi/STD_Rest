using Android.App;
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
    public partial class OrderBar : NavigationBasePage<OrderBarViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.order_at_bar;

        protected override void InitViews()
        {
            base.InitViews();

            ListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                              new OrderBarItemCellViewHolder(inflater,
                                              parent,
                                              ModelView.CellModel)));
        }
    }
    public class OrderBarItemCellViewHolder : ComponentViewHolder<IOrderContent>
    {
        public OrderBarItemCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                       ICrossCellViewHolder<IOrderContent> cellModel)
            : base(inflator.Inflate(Resource.Layout.order_at_bar_item_list, parent, false), cellModel) { }

        [CrossView(nameof(OrderBarViewModel.OrderListBaseCell.CategoryImage))]
        [InjectView(Resource.Id.item_image)]
        public ImageView ItemImage { get; set; }

        [CrossView(nameof(OrderBarViewModel.OrderListBaseCell.ItemNameText))]
        [InjectView(Resource.Id.item_name)]
        public TextView ItemNameText { get; set; }

        [CrossView(nameof(OrderBarViewModel.OrderListBaseCell.QuantityText))]
        [InjectView(Resource.Id.quantity_item)]
        public TextView QuantityText { get; set; }


        [CrossView(nameof(OrderBarViewModel.OrderListBaseCell.PriceText))]
        [InjectView(Resource.Id.price_item)]
        public TextView PriceText { get; set; }

        [CrossView(nameof(OrderBarViewModel.OrderListBaseCell.CellContentRootView))]
        [InjectView(Resource.Id.wrapp_item_content)]
        public View CellContent { get; set; }
    }
}
