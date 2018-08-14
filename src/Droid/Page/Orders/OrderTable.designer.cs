using System;
using Android;
using Android.Widget;
using Core.ViewModels.Beer;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class OrderTable
    {
        [CrossView(nameof(OrderTableViewModel.ListView))]
        [InjectView(Resource.Id.orderbar_list_view)]
        public BaseRecyclerView ListView { get; set; }

        //[CrossView(nameof(OrderBarViewModel.BackroundContent))]
        //[InjectView(Resource.Id.main_content)]
        //public LinearLayout BackroundContent { get; set; }

        [CrossView(nameof(OrderTableViewModel.TableNrText))]
        [InjectView(Resource.Id.table_number_text)]
        public TextView TableNrText { get; set; }

        [CrossView(nameof(OrderTableViewModel.TableNrValueText))]
        [InjectView(Resource.Id.table_value_number_text)]
        public TextView TableNrValueText { get; set; }

        [CrossView(nameof(OrderTableViewModel.ChangeText))]
        [InjectView(Resource.Id.change_text_item)]
        public TextView ChangeText { get; set; }

        [CrossView(nameof(OrderTableViewModel.ChangeImage))]
        [InjectView(Resource.Id.change_image_item)]
        public ImageView ChangeImage { get; set; }

        [CrossView(nameof(OrderTableViewModel.BackroundChange))]
        [InjectView(Resource.Id.change_button_touch_area)]
        public LinearLayout BackroundChange { get; set; }


        [CrossView(nameof(OrderTableViewModel.ConfirmText))]
        [InjectView(Resource.Id.confrim_order)]
        public TextView ConfirmText { get; set; }
    }
}
