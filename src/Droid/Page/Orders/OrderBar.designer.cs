using System;
using Android;
using Android.Widget;
using Core.ViewModels.Beer;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class OrderBar
    {
        [CrossView(nameof(OrderBarViewModel.ListView))]
        [InjectView(Resource.Id.orderbar_list_view)]
        public BaseRecyclerView ListView { get; set; }

        //[CrossView(nameof(OrderBarViewModel.BackroundContent))]
        //[InjectView(Resource.Id.main_content)]
        //public LinearLayout BackroundContent { get; set; }

        [CrossView(nameof(OrderBarViewModel.OrderBackround))]
        [InjectView(Resource.Id.wrapper_order_content)]
        public LinearLayout OrderBackround { get; set; }


        [CrossView(nameof(OrderBarViewModel.OrderCode))]
        [InjectView(Resource.Id.order_code_text)]
        public TextView OrderCode { get; set; }

        [CrossView(nameof(OrderBarViewModel.OrderCodeValue))]
        [InjectView(Resource.Id.order_code_value_text)]
        public TextView OrderCodeValue { get; set; }
    }
}
