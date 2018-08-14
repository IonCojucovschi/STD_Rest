using System;
using Android.Widget;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class Events 
    {
        [CrossView(nameof(EventsViewModel.BackroundContent))]
        [InjectView(Resource.Id.events_content_background)]
        protected LinearLayout BackroundContent { get; set; }

        [CrossView(nameof(EventsViewModel.MonthText))]
        [InjectView(Resource.Id.text_event_top)]
        protected TextView MonthText { get; set; }

        [CrossView(nameof(EventsViewModel.LeftArrow))]
        [InjectView(Resource.Id.left_arrow)]
        protected ImageView LeftArrow { get; set; }

        [CrossView(nameof(EventsViewModel.RightArrow))]
        [InjectView(Resource.Id.right_arrow)]
        protected ImageView RightArrow { get; set; }

        [CrossView(nameof(EventsViewModel.IntervalEventsDate))]
        [InjectView(Resource.Id.interval_date_events)]
        protected TextView IntervalEventsDate { get; set; }

        //[CrossView(nameof(EventsViewModel.SortImage))]
        //[InjectView(Resource.Id.image_event_top)]
        //protected ImageView SortImage { get; set; }

        [CrossView(nameof(EventsViewModel.ListView))]
        [InjectView(Resource.Id.list_tags1)]
        public BaseRecyclerView ListView {get; set;}

        [CrossView(nameof(EventsViewModel.ListSubTagView))]
        [InjectView(Resource.Id.list_tags2)]
        public BaseRecyclerView ListSubTagView { get; set; }

        [CrossView(nameof(EventsViewModel.ListEventNameView))]
        [InjectView(Resource.Id.event_list)]
        public BaseRecyclerView ListEventNameView { get; set; }

    }

}
