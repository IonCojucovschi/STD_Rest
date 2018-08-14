using System;
using Android.Views;
using Android.Widget;
using Core.ViewModels;
using Core.ViewModels.Beer;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class EventDetails
    {
        [CrossView(nameof(EventDetailsViewModel.BackgroundContent))]
        [InjectView(Resource.Id.main_content_view)]
        protected RelativeLayout BackgroundContent { get; set; }

        [CrossView(nameof(EventDetailsViewModel.EventImageShadow))]
        [InjectView(Resource.Id.image_event_wrapper)]
        protected View EventImageWrapper { get; set; }

        [CrossView(nameof(EventDetailsViewModel.EventImage))]
        [InjectView(Resource.Id.events_image)]
        protected ImageView EventImage { get; set; }

        [CrossView(nameof(EventDetailsViewModel.TimeEvent))]
        [InjectView(Resource.Id.time_when_ev_start)]
        protected TextView TimeEvent { get; set; }

        [CrossView(nameof(EventDetailsViewModel.SeparatorImage))]
        [InjectView(Resource.Id.image_date_separator)]
        protected ImageView SeparatorImage { get; set; }

        [CrossView(nameof(EventDetailsViewModel.HourEvent))]
        [InjectView(Resource.Id.hour_when_ev_start)]
        protected TextView HourEvent { get; set; }


        [CrossView(nameof(EventDetailsViewModel.TimeEventBackground))]
        [InjectView(Resource.Id.date_image_background)]
        protected ImageView TimeEventBackground { get; set; }



        [CrossView(nameof(EventDetailsViewModel.EventName))]
        [InjectView(Resource.Id.event_name)]
        protected TextView EventName { get; set; }

        [CrossView(nameof(EventDetailsViewModel.EventDescription))]
        [InjectView(Resource.Id.event_description)]
        protected TextView EventDescription { get; set; }
    }
}
