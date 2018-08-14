
using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.DAL;
using Core.ViewModels.Beer;
using Droid.Helpers;
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
    public partial class OrderTable : NavigationBasePage<OrderTableViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.order_at_table;

        private Action<string> _result { get; set; }

        protected override void InitViews()
        {
            base.InitViews();

            ListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                              new OrderTableItemCellViewHolder(inflater,
                                             parent,
                                             ModelView.CellModel)));

            ModelView.GetPayment -= ModelView_GetPayment;
            ModelView.GetPayment += ModelView_GetPayment;
        }

        private void ModelView_GetPayment(Action<string> arg)
        {
            PPHelper.Buy();
            _result = arg;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            PPHelper.ProcessResponse(requestCode, resultCode, data, (objPayId) =>
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
    public class OrderTableItemCellViewHolder : ComponentViewHolder<IOrderContent>
    {
        public OrderTableItemCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                       ICrossCellViewHolder<IOrderContent> cellModel)
            : base(inflator.Inflate(Resource.Layout.order_at_bar_item_list, parent, false), cellModel) { }

        [CrossView(nameof(OrderTableViewModel.OrderListBaseCell.CategoryImage))]
        [InjectView(Resource.Id.item_image)]
        public ImageView ItemImage { get; set; }

        [CrossView(nameof(OrderTableViewModel.OrderListBaseCell.ItemNameText))]
        [InjectView(Resource.Id.item_name)]
        public TextView ItemNameText { get; set; }

        [CrossView(nameof(OrderTableViewModel.OrderListBaseCell.QuantityText))]
        [InjectView(Resource.Id.quantity_item)]
        public TextView QuantityText { get; set; }


        [CrossView(nameof(OrderTableViewModel.OrderListBaseCell.PriceText))]
        [InjectView(Resource.Id.price_item)]
        public TextView PriceText { get; set; }

        [CrossView(nameof(OrderTableViewModel.OrderListBaseCell.CellContentRootView))]
        [InjectView(Resource.Id.wrapp_item_content)]
        public View CellContent { get; set; }
    }
}
