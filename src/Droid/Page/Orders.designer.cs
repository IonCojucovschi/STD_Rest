using System;
using Android;
using Android.Widget;
using Core.ViewModels.Beer;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class Orders
    {
        [CrossView(nameof(OrderViewModel.ListView))]
        [InjectView(Resource.Id.orders_list)]
        public BaseRecyclerView ListView { get; set; }

    }
}
